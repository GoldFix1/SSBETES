using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using SSBETES.Buffs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using SSBETES.Helpers;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using static Terraria.ModLoader.PlayerDrawLayer;
using SSBETES.Model;
using DBZGoatLib.Model;

namespace SSBETES
{
    public class BPlayer : ModPlayer
    {
        public bool SSBEAchieved;
        public bool SSBEActive;
        public bool SSBEUnlockMsg;
        public bool MP_Unlock;

        public DateTime? Offset = null;

        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        private TransformationInfo? Form = null;

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SSBETES_SSBEAchieved", SSBEAchieved);
            tag.Add("SSBETES_SSBEUnlockMsg", SSBEUnlockMsg);
        }
        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("SSBETES_SSBEAchieved"))
                SSBEAchieved = tag.GetBool("SSBETES_SSBEAchieved");
            if (tag.ContainsKey("SSBETES_SSBEUnlockMsg"))
                SSBEUnlockMsg = tag.GetBool("SSBETES_SSBEUnlockMsg");
        }
        
        public static BPlayer ModPlayer(Player player) => player.GetModPlayer<BPlayer>();
       
        public static bool MasteredSSBE(Player player) => GPlayer.ModPlayer(player).GetMastery(ModContent.BuffType<SSBEBuff>()) >= 1f;
        
        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();
            if(ModLoader.TryGetMod("dbzcalamity", out Mod dbcamod))
            {
                var ModPlayerClass = dbcamod.Code.DefinedTypes.First(x => x.Name.Equals("dbzcalamityPlayer"));
                var getModPlayer = ModPlayerClass.GetMethod("ModPlayer");

                dynamic dbzPlayer = getModPlayer.Invoke(null, new object[] {Player});

                var dodgeChance = ModPlayerClass.GetField("dodgeChange");
                dodgeChance.SetValue(dbzPlayer, (float)dodgeChance.GetValue(dbzPlayer) - .05f);
            }

        }

        public override void PreUpdate()
        {
            if (ModLoader.HasMod("DBZMODPORT"))
            {
                var transformationHelper = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("TransformationHelper"));
                bool IsSSJB = (bool)transformationHelper.GetMethod("IsSSJB").Invoke(null, new object[] { Player });

                if (!IsSSJB)
                    Offset = null;

                if (IsSSJB && !Offset.HasValue)
                    Offset = DateTime.Now;

                if (BalanceConfigServer.Instance.KiRework)
                {
                    var MyPlayerClass = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer"));
                    dynamic myPlayer = MyPlayerClass.GetMethod("ModPlayer").Invoke(null, new object[] { Player });
                    var kiRegenTimer = MyPlayerClass.GetField("kiRegenTimer", SSBETES.flagsAll);
                    var kiChargeRate = MyPlayerClass.GetField("kiChargeRate");

                    kiRegenTimer.SetValue(myPlayer, 0);
                    kiChargeRate.SetValue(myPlayer, myPlayer.kiChargeRate + myPlayer.kiRegen);
                }
            }
        }

        public override void PostUpdate()
        {
            if (MP_Unlock && Main.netMode == NetmodeID.MultiplayerClient)
            {
                dynamic modPlayer = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer")).GetMethod("ModPlayer").Invoke(null, new object[] { Player });

                float mastery = (float)modPlayer.masteryLevelLeg3;

                if (mastery >= 1f)
                {
                    SSBEAchieved = true;
                    MP_Unlock = false;
                }
            }
            if(SSBEAchieved && !SSBEUnlockMsg)
            {
                SSBEUnlockMsg = true;
                if (Main.netMode != NetmodeID.Server)
                {
                    Main.NewText("You have unlocked your true potential. Super Saiyan Blue Evolution has been achieved!", Color.Green);
                    TransformationHandler.ClearTransformations(Player);
                    TransformationHandler.Transform(Player, TransformationHandler.GetTransformation("SSBEBuff").Value);
                }
            }

            if (ModLoader.HasMod("DBZMODPORT"))
            {
                if (BalanceConfigServer.Instance.KiRework)
                {
                    var MyPlayerClass = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer"));
                    dynamic myPlayer = MyPlayerClass.GetMethod("ModPlayer").Invoke(null, new object[] { Player });
                    var kiChargeRate = MyPlayerClass.GetField("kiChargeRate");

                    kiChargeRate.SetValue(myPlayer, myPlayer.kiChargeRate + myPlayer.kiRegen);
                }
            }
        }
        public override void ResetEffects()
        {
            if (ModLoader.HasMod("DBZMODPORT"))
            {
                if (BalanceConfigServer.Instance.KiRework)
                {
                    var MyPlayerClass = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer"));
                    dynamic myPlayer = MyPlayerClass.GetMethod("ModPlayer").Invoke(null, new object[] { Player });
                    var kiChargeRate = MyPlayerClass.GetField("kiChargeRate");

                    kiChargeRate.SetValue(myPlayer, myPlayer.kiChargeRate + myPlayer.kiRegen);
                }
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (MyPlayerClass.MySpecialHotkey.JustPressed)
            {
                if (!TransformationHandler.IsTransformed(Player))
                {
                    TransformationHandler.Transform(Player, LSSJ4.LSSJ4Info);
        else
                        TransformationHandler.EndTransformation(Player, LSSJ4.LSSJ4Info);
                }
            }

        public void HandleTransformationInput()
        {
            dynamic self = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer")).GetMethod("ModPlayer").Invoke(null, new object[] { Player });
            if (TransformationHandler.TransformKey.Current && !TransformationHandler.IsTransformed(Player))
            {
                self.isCharging = true;

                if (!PoweringUpTime.HasValue)
                {
                    PoweringUpTime = DateTime.Now;
                    LastPowerUpTick = DateTime.Now;

                    CombatText.NewText(Player.Hitbox, Color.Yellow, "3");
                    return;
                }

                else if (PoweringUpTime.HasValue && LastPowerUpTick.HasValue)
                {
                    int secs = (int)(3 - (DateTime.Now - PoweringUpTime.Value).TotalSeconds);
                    if ((DateTime.Now - LastPowerUpTick.Value).TotalMilliseconds >= 666 && secs > 0)
                    {
                        LastPowerUpTick = DateTime.Now;
                        CombatText.NewText(Player.Hitbox, Color.Yellow, $"{secs}");
                        return;
                    }
                    if ((DateTime.Now - PoweringUpTime.Value).TotalMilliseconds >= 2000)
                    {
                        if (Form.HasValue)
                            TransformationHandler.Transform(Player, Form.Value);
                    }
                }
            }
            else if (TransformationHandler.IsTransformed(Player))
            {
                if (Form.HasValue)
                    TransformationHandler.Transform(Player, Form.Value);
            }
            else
            {
                PoweringUpTime = null;
                LastPowerUpTick = null;
            }
        }
    }
}
