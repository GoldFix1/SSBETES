using System;
using System.IO;
using System.Security.Policy;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Steamworks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using DBZGoatLib;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZMODPORT.Buffs.SSJBuffs;
using DBZMODPORT.Util;
using DBZMODPORT;
using SSBETES.Buffs.Transformations;
using SSBETES.Buffs.Traits;
using SSBETES.Buffs.Debuffs;
using SSBETES.Changes;
using SSBETES;
using DBZMODPORT.Enums;
using DBZMODPORT.Projectiles.AuraProjectiles;
using System.Linq.Expressions;
//using oozaru;
//using oozaru.Assets;
//using oozaru.Transformations;
//using SteelSeries.GameSense;

namespace SSBETES.Assets
{
    internal class BUPPlayer : ModPlayer
    {

        public bool FSSJActive;
        public bool FSSJUnlockMsg;
        public bool FSSJAchieved;

        public bool BERSERKERActive;
        public bool BERSERKERUnlockMsg;
        public bool BERSERKERAchieved;

        public bool ConBERSERKERActive;
        public bool ConBERSERKERUnlockMsg;
        public bool ConBERSERKERAchieved;

        public bool EvilSaiyanActive;
        public bool EvilSaiyanUnlockMsg;
        public bool EvilSaiyanAchieved;

        public bool IKARIActive;
        public bool IKARIUnlockMsg;
        public bool IKARIAchieved;

        public bool FPSSJActive;
        public bool FPSSJUnlockMsg;
        public bool FPSSJAchieved;

        public bool SSJFPActive;
        public bool SSJFPUnlockMsg;
        public bool SSJFPAchieved;

        public bool SSJRGActive;
        public bool SSJRGUnlockMsg;
        public bool SSJRGAchieved;

        public bool PSSBActive;
        public bool PSSBUnlockMsg;
        public bool PSSBAchieved;

        public bool SSBEActive;
        public bool SSBEUnlockMsg;
        public bool SSBEAchieved;

        public bool SSBKKActive;
        public bool SSBKKUnlockMsg;
        public bool SSBKKAchieved;

        public bool SSJ100Active;
        public bool SSJ100UnlockMsg;
        public bool SSJ100Achieved;

        public bool UBActive;
        public bool UBUnlockMsg;
        public bool UBAchieved;

        public bool TESTActive;
        public bool TESTUnlockMsg;
        public bool TESTAchieved;

        public bool isAncient;
        public bool isMajin;
        public bool isMightyFruitAte;
        public bool hasBuffs;
        public bool MP_Unlock;

        //public bool isEvilBossAlive;
        //public bool isWallOfFleshAlive;

        public int IkariTimer;
        public bool Unlocking;
        public bool RageSign;

        public static ModKeybind PowerUp;
        public static ModKeybind Ability;

        public Texture2D hair;
        public Color? originalEyeColor;
        public Color? originalSkinColor;

        public DateTime? Offset = null;
        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        private TransformationInfo? Form = null;

        public override void PostUpdate()
        {
            Player player = Main.player[Main.myPlayer];
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();

            bool isEvilBossAlive = false;
            bool FalseAwaken1 = false;

            foreach (NPC npc in Main.npc)
            {
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.BrainofCthulhu)
                {
                    isEvilBossAlive = true;
                }
                
                if (npc.type == NPCID.WallofFlesh && npc.life <= 10)
                {
                    if (!BUPPlayer.IKARIAchieved)
                    {
                        BUPPlayer.IKARIAchieved = true;
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("IKARIBuff").Value);
                    }
                }

                if (npc.type == NPCID.QueenSlimeBoss && npc.life <= 10 && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin")
                {
                    if (!BUPPlayer.RageSign)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDustPerfect(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 10), (float)(player.width + 10)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 10), (float)(player.height + 10))), 137,
                            new Vector2?(Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(100f))), 0, default(Color), 1f).noGravity = true;

                            Dust.NewDustPerfect(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 10), (float)(player.width + 10)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 10), (float)(player.height + 10))), 142,
                            new Vector2?(Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(100f))), 0, default(Color), 1f).noGravity = true;
                            BUPPlayer.RageSign = true;
                        }
                        Main.NewText("Cult will open gates to new form!", Color.DeepSkyBlue);
                    }
                }
                if (npc.type == NPCID.CultistBoss && BUPPlayer.RageSign && npc.life <= 10)
                {
                    if (!BUPPlayer.SSJRGAchieved)
                    {
                        BUPPlayer.SSJRGAchieved = true;
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJRGBuff").Value);
                    }
                }
            }

            if (player.GetModPlayer<GPlayer>().Trait == "Ancient")
            {
                if (NPC.downedBoss1 && !NPC.downedBoss3 && !NPC.downedMechBossAny)
                {
                    Player.AddBuff(ModContent.BuffType<UnknownAncient>(), 120);
                }
                else if (NPC.downedBoss1 && NPC.downedBoss3 && !NPC.downedMechBossAny)
                {
                    Player.ClearBuff(ModContent.BuffType<UnknownAncient>());
                    Player.AddBuff(ModContent.BuffType<AncientBuff>(), 120);
                }
            }

            if (player.GetModPlayer<GPlayer>().Trait == "Majin")
            {
                if (NPC.downedBoss1 && !NPC.downedBoss3 && !NPC.downedMechBossAny)
                {
                    Player.AddBuff(ModContent.BuffType<UnknownMajin>(), 120);
                }
                else if (NPC.downedBoss1 && NPC.downedBoss3 && !NPC.downedMechBossAny)
                {
                    Player.ClearBuff(ModContent.BuffType<UnknownMajin>());
                    Player.AddBuff(ModContent.BuffType<MajinBuff>(), 120);
                }
            }

            if (isEvilBossAlive) //NPC.downedBoss2
            {
                if (!BUPPlayer.FSSJAchieved && (player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin"))
                {
                    if ((player.statLife <= player.statLifeMax2 / 1.5f) && !FalseAwaken1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Dust.NewDustPerfect(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 10), (float)(player.width + 10)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 10), (float)(player.height + 10))), 108,
                            new Vector2?(Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(100f))), 0, default(Color), 1f).noGravity = true;                        
                        }
                        FalseAwaken1 = true;
                    }

                    if ((player.statLife <= player.statLifeMax2 / 4) && FalseAwaken1)
                    {
                        BUPPlayer.FSSJAchieved = true;
                        Player.HealEffect(300, true);
                        TransformationHandler.ClearTransformations(base.Player);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("FSSJBuff").Value);
                    }
                }
            }

            /*
            if (isWallOfFleshAlive)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();
                if (!BUPPlayer.IKARIAchieved && player.GetModPlayer<GPlayer>().Trait == "Legendary")
                {
                    BUPPlayer.IKARIAchieved = true;
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("IKARIBuff").Value);
                }
            }
            */

            if (FSSJAchieved && !FSSJUnlockMsg)
            {
                FSSJUnlockMsg = true;
                Main.NewText("The anger fills your body!", Color.DarkGoldenrod);
            }

            if (EvilSaiyanAchieved && !EvilSaiyanUnlockMsg)
            {
               EvilSaiyanUnlockMsg = true;
                if (player.GetModPlayer<GPlayer>().Trait == "Ancient")
                {
                    Main.NewText("Evil Ki overwhelms you!", new Color(137, 29, 35));
                }
                    
            }

            if (BERSERKERAchieved && !BERSERKERUnlockMsg)
            {
                BERSERKERUnlockMsg = true;
                //Main.NewText("Evil Ki overwhelms you!", new Color(137, 29, 35));
            }

            if (ConBERSERKERAchieved && !ConBERSERKERUnlockMsg)
            {
                ConBERSERKERUnlockMsg = true;
                //Main.NewText("Evil Ki overwhelms you!", new Color(137, 29, 35));
            }

            if(Unlocking)
            {
                IKARIAchieved = true;
            }

            if (IKARIAchieved && !IKARIUnlockMsg)
            {
                IKARIUnlockMsg = true;
                Main.NewText("Rage has opened up new possibilities for you!", Color.LawnGreen);
            }

            if (player.GetModPlayer<MyPlayer>().masteryLevel1 >= 1f)
            {
                //this.SSJBTransformation();
                //this.isTransforming = true;
                FPSSJAchieved = true;
                SSJFPAchieved = true;
            }

            if (FPSSJAchieved && !FPSSJUnlockMsg)
            {
                FPSSJUnlockMsg = true;
                if (player.GetModPlayer<GPlayer>().Trait == "Legendary")
                {
                    Main.NewText("You got Full Power Super Saiyan!", Color.GreenYellow);
                }
            }

            if (SSJFPAchieved && !SSJFPUnlockMsg)
            {
                SSJFPUnlockMsg = true;
                if (player.GetModPlayer<GPlayer>().Trait != "Legendary")
                {
                    Main.NewText("You got Super Saiyan Full Power!", Color.Gold);
                }
            }

            if (SSJRGAchieved && !SSJRGUnlockMsg)
            {
                SSJRGUnlockMsg = true;
                //Main.NewText("", Color.Yellow);
            }

            if (MP_Unlock && Main.netMode == NetmodeID.MultiplayerClient)
            {
                dynamic modPlayer = SSBETES.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer")).GetMethod("ModPlayer").Invoke(null, new object[] { Player });

                float mastery = (float)modPlayer.masteryLevelBlue;

                if (mastery >= 1f)
                {
                    PSSBAchieved = true;
                }
            }

            if (player.GetModPlayer<MyPlayer>().masteryLevelBlue >= 1f)
            {
                PSSBAchieved = true;
            }

            if (PSSBAchieved && !PSSBUnlockMsg)
            {             
                PSSBUnlockMsg = true;
                Main.NewText("You have perfected SSJB.", Color.LightSkyBlue);
                TransformationHandler.ClearTransformations(base.Player);
                TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("PSSBBuff").Value);
            }

            if (SSBEAchieved && !SSBEUnlockMsg)
            {
                SSBEUnlockMsg = true;
                Main.NewText("Your pride unlocked your true potential. Super Saiyan Blue Evolution has been achieved!", new Color(0, 40, 163));
            }

            if (SSBKKAchieved && !SSBKKUnlockMsg)
            {
                SSBKKUnlockMsg = true;
                Main.NewText("Now you are able to combine your god form with old techique!", Color.Aquamarine);
            }

            if (UBAchieved && !UBUnlockMsg)
            {
                UBUnlockMsg = true;
                Main.NewText("You have absorbed universal power!", Color.Cyan);
            }

            if (SSJ100Achieved && !SSJ100UnlockMsg)
            {
                SSJ100UnlockMsg = true;
                Main.NewText("You have achieved true saiyan power!", Color.Orange);
            }

            if (TESTAchieved && !TESTUnlockMsg)
            {
                TESTUnlockMsg = true;
                Main.NewText("ETST");
            }
        }

        public override void PostUpdateEquips()
        {
            if (this.isAncient && base.Player.HasBuff<EvilSaiyanBuff>())
            {
                for (int j = 0; j < 255; j++)
                {
                    if (Main.player[j].active && Main.player[j].whoAmI != base.Player.whoAmI)
                    {
                        if ((Main.player[j].Center - base.Player.Center).Length() <= 1200f)
                        {
                            if (!Main.player[j].HasBuff<BERSERKERBuff>())
                            {
                                TransformationHandler.Transform(Main.player[j], TransformationHandler.GetTransformation("BERSERKERBuff").Value);
                            }
                        }
                        else if (Main.player[j].HasBuff<BERSERKERBuff>())
                        {
                            int index = Main.player[j].FindBuffIndex(ModContent.BuffType<BERSERKERBuff>());
                            Main.player[j].DelBuff(index);
                        }
                    }
                }
            }
        }

        public override void SaveData(TagCompound tag)
        {
            //TraitHandler.RegisterTrait(EvilSaiyan);

            tag.Add("isAncient", isAncient);
            tag.Add("isMajin", isMajin);
            tag.Add("hasBuffs", hasBuffs);

            tag.Add("SSBETES_FSSJAchieved", FSSJAchieved);
            tag.Add("SSBETES_FSSJUnlockMsg", FSSJUnlockMsg);

            tag.Add("SSBETES_IKARIAchieved", IKARIAchieved);
            tag.Add("SSBETES_IKARIUnlockMsg", IKARIUnlockMsg);

            tag.Add("SSBETES_EvilSaiyanAchieved", EvilSaiyanAchieved);
            tag.Add("SSBETES_EvilSaiyanUnlockMsg", EvilSaiyanUnlockMsg);

            tag.Add("SSBETES_BERSERKERAchieved", BERSERKERAchieved);
            tag.Add("SSBETES_BERSERKERUnlockMsg", BERSERKERUnlockMsg);

            tag.Add("SSBETES_FPSSJAchieved", FPSSJAchieved);
            tag.Add("SSBETES_FPSSJUnlockMsg", FPSSJUnlockMsg);

            tag.Add("SSBETES_SSJFPAchieved", SSJFPAchieved);
            tag.Add("SSBETES_SSJFPUnlockMsg", SSJFPUnlockMsg);

            tag.Add("SSBETES_SSJRGAchieved", SSJRGAchieved);
            tag.Add("SSBETES_SSJRGUnlockMsg", SSJRGUnlockMsg);

            tag.Add("SSBETES_PSSBAchieved", PSSBAchieved);
            tag.Add("SSBETES_PSSBUnlockMsg", PSSBUnlockMsg);

            tag.Add("SSBETES_SSBEAchieved", SSBEAchieved);
            tag.Add("SSBETES_SSBEUnlockMsg", SSBEUnlockMsg);

            tag.Add("SSBETES_SSBKKAchieved", SSBKKAchieved);
            tag.Add("SSBETES_SSBKKUnlockMsg", SSBKKUnlockMsg);

            tag.Add("SSBETES_UBAchieved", UBAchieved);
            tag.Add("SSBETES_UBUnlockMsg", UBUnlockMsg);

            tag.Add("SSBETES_SSJ100Achieved", SSJ100Achieved);
            tag.Add("SSBETES_SSJ100UnlockMsg", SSJ100UnlockMsg);

            tag.Add("SSBETES_TESTAchieved", TESTAchieved);
            tag.Add("SSBETES_TESTUnlockMsg", TESTUnlockMsg);
            
            if (this.originalEyeColor != null)
            {
                tag.Add("OriginalEyeColorR", this.originalEyeColor.Value.R);
                tag.Add("OriginalEyeColorG", this.originalEyeColor.Value.G);
                tag.Add("OriginalEyeColorB", this.originalEyeColor.Value.B);
            }
            
            if (this.originalSkinColor != null)
            {
                tag.Add("OriginalSkinColorR", this.originalSkinColor.Value.R);
                tag.Add("OriginalSkinColorG", this.originalSkinColor.Value.G);
                tag.Add("OriginalSkinColorB", this.originalSkinColor.Value.B);
            }
        }

        public override void LoadData(TagCompound tag)
        {

            isAncient = tag.GetBool("isAncient");
            isMajin = tag.GetBool("isMajin");
            hasBuffs = tag.GetBool("hasBuffs");

            if (tag.ContainsKey("SSBETES_FSSJAchieved"))
                FSSJAchieved = tag.GetBool("SSBETES_FSSJAchieved");
            if (tag.ContainsKey("SSBETES_FSSJUnlockMsg"))
                FSSJUnlockMsg = tag.GetBool("SSBETES_FSSJUnlockMsg");

            if (tag.ContainsKey("SSBETES_IKARIAchieved"))
                IKARIAchieved = tag.GetBool("SSBETES_IKARIAchieved");
            if (tag.ContainsKey("SSBETES_IKARIUnlockMsg"))
                IKARIUnlockMsg = tag.GetBool("SSBETES_IKARIUnlockMsg");

            if (tag.ContainsKey("SSBETES_BERSERKERAchieved"))
                BERSERKERAchieved = tag.GetBool("SSBETES_BERSERKERAchieved");
            if (tag.ContainsKey("SSBETES_BERSERKERUnlockMsg"))
                BERSERKERUnlockMsg = tag.GetBool("SSBETES_BERSERKERUnlockMsg");

            if (tag.ContainsKey("SSBETES_EvilSaiyanAchieved"))
                EvilSaiyanAchieved = tag.GetBool("SSBETES_EvilSaiyanAchieved");
            if (tag.ContainsKey("SSBETES_EvilSaiyanUnlockMsg"))
                EvilSaiyanUnlockMsg = tag.GetBool("SSBETES_EvilSaiyanUnlockMsg");

            if (tag.ContainsKey("SSBETES_FPSSJAchieved"))
                FPSSJAchieved = tag.GetBool("SSBETES_FPSSJAchieved");
            if (tag.ContainsKey("SSBETES_FPSSJUnlockMsg"))
                FPSSJUnlockMsg = tag.GetBool("SSBETES_FPSSJUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSJFPAchieved"))
                SSJFPAchieved = tag.GetBool("SSBETES_SSJFPAchieved");
            if (tag.ContainsKey("SSBETES_SSJFPUnlockMsg"))
                SSJFPUnlockMsg = tag.GetBool("SSBETES_SSJFPUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSJRGAchieved"))
                SSJRGAchieved = tag.GetBool("SSBETES_SSJRGAchieved");
            if (tag.ContainsKey("SSBETES_SSJRGUnlockMsg"))
                SSJRGUnlockMsg = tag.GetBool("SSBETES_SSJRGUnlockMsg");

            if (tag.ContainsKey("SSBETES_PSSBAchieved"))
                PSSBAchieved = tag.GetBool("SSBETES_PSSBAchieved");
            if (tag.ContainsKey("SSBETES_PSSBUnlockMsg"))
                PSSBUnlockMsg = tag.GetBool("SSBETES_PSSBUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSBEAchieved"))
                SSBEAchieved = tag.GetBool("SSBETES_SSBEAchieved");
            if (tag.ContainsKey("SSBETES_SSBEUnlockMsg"))
                SSBEUnlockMsg = tag.GetBool("SSBETES_SSBEUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSBKKAchieved"))
                SSBKKAchieved = tag.GetBool("SSBETES_SSBKKAchieved");
            if (tag.ContainsKey("SSBETES_SSBKKUnlockMsg"))
                SSBKKUnlockMsg = tag.GetBool("SSBETES_SSBKKUnlockMsg");

            if (tag.ContainsKey("SSBETES_UBAchieved"))
                UBAchieved = tag.GetBool("SSBETES_UBAchieved");
            if (tag.ContainsKey("SSBETES_UBUnlockMsg"))
                UBUnlockMsg = tag.GetBool("SSBETES_UBUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSJ100Achieved"))
                SSJ100Achieved = tag.GetBool("SSBETES_SSJ100Achieved");
            if (tag.ContainsKey("SSBETES_SSJ100UnlockMsg"))
                SSJ100UnlockMsg = tag.GetBool("SSBETES_SSJ100UnlockMsg");

            if (tag.ContainsKey("SSBETES_TESTAchieved"))
                TESTAchieved = tag.GetBool("SSBETES_TESTAchieved");
            if (tag.ContainsKey("SSBETES_TESTUnlockMsg"))
                TESTUnlockMsg = tag.GetBool("SSBETES_TESTUnlockMsg");
            /*
            if (tag.ContainsKey("OriginalEyeColorR") && tag.ContainsKey("OriginalEyeColorG") && tag.ContainsKey("OriginalEyeColorB"))
            {
                this.originalEyeColor = new Color?(new Color((int)tag.Get<byte>("OriginalEyeColorR"), (int)tag.Get<byte>("OriginalEyeColorG"), (int)tag.Get<byte>("OriginalEyeColorB")));
            }
            */
        }

        public override void OnEnterWorld(Player player)
        {
            TraitHandler.RollTrait(true);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player player = Main.player[Main.myPlayer];
            //var OPlayer = player.GetModPlayer<ModPlayer>();
            //OPlayer oPlayer = player.GetModPlayer<OPlayer>();
            bool NotPrimal = true;

            if (PowerUp.JustPressed)
            {
                if ((player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin") && player.GetModPlayer<MyPlayer>().masteryLevel1 != 0 && !base.Player.HasBuff<SSJ1Buff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<FSSJBuff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ1Buff").Value);
                }

                if ((player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin") && this.SSJFPUnlockMsg && !base.Player.HasBuff<SSJFPBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJ1Buff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJFPBuff").Value);
                }

                if (player.GetModPlayer<GPlayer>().Trait == "Legendary" && this.FPSSJUnlockMsg && !base.Player.HasBuff<FPSSJBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJFPBuff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("FPSSJBuff").Value);
                }

                if ((player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin") && (player.GetModPlayer<MyPlayer>().masteryLevel2 != 0 || player.GetModPlayer<MyPlayer>().masteryLevelLeg != 0) && (!base.Player.HasBuff<SSJ2Buff>() || !base.Player.HasBuff<LSSJBuff>()) && !base.Player.HasBuff<Cooldown>() && (base.Player.HasBuff<SSJFPBuff>() || base.Player.HasBuff<FPSSJBuff>()))
                {
                    if (player.GetModPlayer<GPlayer>().Trait != "Legendary")
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ2Buff").Value);
                    }
                    if (player.GetModPlayer<GPlayer>().Trait == "Legendary")
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("LSSJBuff").Value);
                    }
                }

                if ((player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin") && this.SSJRGUnlockMsg && !base.Player.HasBuff<SSJRGBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJ2Buff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJRGBuff").Value);
                }

                if ((player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal") && player.GetModPlayer<MyPlayer>().masteryLevelBlue != 0 && !base.Player.HasBuff<SSJBBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJGBuff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJBBuff").Value);
                }

                if (this.PSSBUnlockMsg && !base.Player.HasBuff<PSSBBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJBBuff>())
                {
                    if (player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin")
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("PSSBBuff").Value);
                    }
                    
                    else if (player.GetModPlayer<GPlayer>().Trait == "Ancient")
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJRBuff").Value);
                    }                 
                }

                if (this.SSBEUnlockMsg && !base.Player.HasBuff<SSBEBuff>() && !base.Player.HasBuff<Cooldown>() && (base.Player.HasBuff<PSSBBuff>() || base.Player.HasBuff<SSBKKBuff>()))
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSBEBuff").Value);
                }

                if (this.SSBKKUnlockMsg && !base.Player.HasBuff<SSBKKBuff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSBEBuff>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSBKKBuff").Value);
                }
                /*
                if(ModLoader.HasMod("TraitsPlus"))
                {
                    NotPrimal = false;
                }
                if(ModLoader.HasMod("oozaru"))
                {
                    if (player.GetModPlayer<OPlayer>().SSJ4Achieved && base.Player.HasBuff<SSJ3Buff>() && !base.Player.HasBuff<Cooldown>() && (NotPrimal || player.GetModPlayer<GPlayer>().Trait == "Primal"))
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4Buff").Value);
                    }

                    if (player.GetModPlayer<OPlayer>().SSJ4FPAchieved && base.Player.HasBuff<SSJ4Buff>() && !base.Player.HasBuff<Cooldown>() && (NotPrimal || player.GetModPlayer<GPlayer>().Trait == "Primal"))
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4FPBuff").Value);
                    }

                    if (player.GetModPlayer<OPlayer>().SSJ4LBAchieved && base.Player.HasBuff<SSJ4FPBuff>() && !base.Player.HasBuff<Cooldown>() && (NotPrimal || player.GetModPlayer<GPlayer>().Trait == "Primal"))
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJLBBuff").Value);
                    }

                    if (player.GetModPlayer<OPlayer>().SSJ5Achieved && base.Player.HasBuff<SSJ4LBBuff>() && !base.Player.HasBuff<Cooldown>() && (NotPrimal || player.GetModPlayer<GPlayer>().Trait == "Primal"))
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ5Buff").Value);
                    }

                    if (player.GetModPlayer<OPlayer>().SSJ5FPAchieved && base.Player.HasBuff<SSJ5Buff>() && !base.Player.HasBuff<Cooldown>() && (NotPrimal || player.GetModPlayer<GPlayer>().Trait == "Primal"))
                    {
                        TransformationHandler.ClearTransformations(base.Player);
                        player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                        TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ5FPBuff").Value);
                    }
                }

                
                if (ModLoader.TryGetMod("oozaru", out Mod ooz))
                {

                }
                */
            }

            if (Ability.JustPressed)
            {
                if (player.GetModPlayer<GPlayer>().Trait == "Legendary")
                {
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("IKARIBuff").Value);
                }
                if (player.GetModPlayer<GPlayer>().Trait == "Ancient")
                {
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("EvilSaiyanBuff").Value);
                }
            }

            /*
            if (player.GetModPlayer<GPlayer>().Trait == "Primal" && player.GetModPlayer<OPlayer>().SSJ4Achieved && PowerUp.JustPressed && !base.Player.HasBuff<SSJ4Buff>() && !base.Player.HasBuff<Cooldown>() && base.Player.HasBuff<SSJ3Buff>())
            {
                TransformationHandler.ClearTransformations(base.Player);
                player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4Buff").Value);
            }
            */
        }

        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            if (this.hair != null && !drawInfo.fullHair)
            {
                drawInfo.drawPlayer.head = 0;
            }

            if (this.isAncient)
            {
                this.ChangeEyeColor(Color.Red);
                return;
            }
            if (this.isMajin)
            {
                this.ChangeEyeColor(Color.Black);
                this.ChangeSkinColor(Color.HotPink);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.FSSJActive)
            {
                this.ChangeEyeColor(Color.White);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.EvilSaiyanActive)
            {
                //drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.BERSERKERActive)
            {
                this.ChangeEyeColor(Color.White);
                return;
            }
            if (this.IKARIActive)
            {
                this.ChangeEyeColor(Color.Yellow);
                return;
            }
            if (this.FPSSJActive)
            {
                drawInfo.colorHair = Color.Transparent;
                this.ChangeEyeColor(Color.White);
                return;
            }
            if (this.SSJFPActive)
            {
                drawInfo.colorHair = Color.Transparent;
                this.ChangeEyeColor(Color.Turquoise);
                return;
            }
            if (this.SSJRGActive)
            {
                drawInfo.colorHair = Color.Transparent;
                this.ChangeEyeColor(Color.DeepSkyBlue);
                return;
            }
            if (this.PSSBActive)
            {
                this.ChangeEyeColor(Color.Aqua);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.SSBKKActive)
            {
                this.ChangeEyeColor(Color.Aquamarine);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.SSBEActive)
            {
                this.ChangeEyeColor(Color.Blue);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.SSJ100Active)
            {
                this.ChangeEyeColor(Color.White);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.UBActive)
            {
                this.ChangeEyeColor(Color.Cyan);
                drawInfo.colorHair = Color.Transparent;
                return;
            }
            if (this.originalEyeColor != null && base.Player.eyeColor != this.originalEyeColor.Value)
            {
                base.Player.eyeColor = this.originalEyeColor.Value;
            }
            if (this.originalSkinColor != null && base.Player.skinColor != this.originalSkinColor.Value)
            {
                base.Player.skinColor = this.originalSkinColor.Value;
            }
        }

        public void ChangeEyeColor(Color eyeColor)
        {
            if (this.originalEyeColor == null)
            {
                this.originalEyeColor = new Color?(base.Player.eyeColor);
            }
            base.Player.eyeColor = eyeColor;
        }

        public void ChangeSkinColor(Color skinColor)
        {
            if (this.originalSkinColor == null)
            {
                this.originalSkinColor = new Color?(base.Player.skinColor);
            }
            base.Player.skinColor = skinColor;
        }

        /*
        public class BSSFPanel : TransformationTree
        {
            public override bool Complete() => false;

            public override bool Condition(Player player)
            {
                if(Config.Instance.NotSepTree)
                {
                    var BUPplayer = player.GetModPlayer<BUPPlayer>();

                    return true;
                }
                else { return false; }

            }

            //{
            //    var modPlayer = player.GetModPlayer<BUPPlayer>();
            //    
            //    return player.GetModPlayer<GPlayer>().Trait == "Prodigy"; //&& player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJB>()) >= 1;
            //    
            //    return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
            //}

            public override Connection[] Connections() => new Connection[]
            {
            new Connection(5,4,1,false,new Gradient(Color.RoyalBlue).AddStop(0.60f, new Color(0, 0, 255))),
            //Color.RoyalBlue
            new Connection(6,4,1,false,new Gradient(Color.Turquoise).AddStop(0.60f, new Color(0, 174, 152))),
            };

            public override string Name() => "Bonus Forms";

            public override Node[] Nodes() => new Node[]
            {
            new Node(0, 4, "FSSJBuff", "SSBETES/Transformations/FSSJBuff", ".",UnlockConditionFSSJ,DiscoverConditionFSSJ),
            new Node(0, 0, "FPSSJBuff", "SSBETES/Transformations/FPSSJBuff", "Master SSJ.",UnlockConditionFPSSJ,DiscoverConditionFPSSJ),
            new Node(1, 0, "SSJFPBuff", "SSBETES/Transformations/SSJFPBuff", "Master SSJ.",UnlockConditionSSJFP,DiscoverConditionSSJFP),
            new Node(3, 1, "SSJRGBuff", "SSBETES/Transformations/SSJRGBuff", "Spirit Sword will unlock this form.",UnlockConditionSSJRG,DiscoverConditionSSJRG),
            //new Node(0, 3, "IKARIBuff", "SSBETES/Transformations/IKARIBuff", "(wall of flesh)",UnlockConditionIKARI,DiscoverConditionIKARI),           
            new Node(6, 4, "PSSBBuff", "SSBETES/Transformations/PSSBBuff", "Lunar creature can perfect your strongest form.",UnlockConditionPSSB,DiscoverConditionPSSB),
            new Node(5, 4, "SSBEBuff", "SSBETES/Transformations/SSBEBuff", "Master your Perfect BLUE abilities.",UnlockConditionSSBE,DiscoverConditionSSBE), //Only gifted warriors can achieve such strength through training.
            new Node(7, 4, "SSBKKBuff", "SSBETES/Transformations/SSBKKBuff", "Master your Perfect BLUE abilities.",UnlockConditionSSBKK,DiscoverConditionSSBKK), //Train harder in your god form.

             new Node(2, 4, "IKARIBuff", "SSBETES/Transformations/IKARIBuff", "Master your Perfect BLUE abilities.",UnlockConditionIKARI,DiscoverConditionIKARI), //Only gifted warriors can achieve such strength through training.
            new Node(3, 4, "BERSERKERBuff", "SSBETES/Transformations/BERSERKERBuff", "Master your Perfect BLUE abilities.",UnlockConditionBERSERKER,DiscoverConditionBERSERKER), //Train harder in your god form.

            };

            public bool UnlockConditionFSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return BUPPlayer.FSSJAchieved;
            }

            public bool DiscoverConditionFSSJ(Player player)
            {
                return true;
            }

            public bool UnlockConditionIKARI(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary" && BUPPlayer.IKARIAchieved;
            }

            public bool DiscoverConditionIKARI(Player player)
            {
                return true;
            }

            public bool UnlockConditionBERSERKER(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Ancient" && BUPPlayer.BERSERKERAchieved;
            }

            public bool DiscoverConditionBERSERKER(Player player)
            {
                return true;
            }

            public bool UnlockConditionFPSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary" && BUPPlayer.FPSSJAchieved;
            }

            public bool DiscoverConditionFPSSJ(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJFP(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && BUPPlayer.SSJFPAchieved;
            }

            public bool DiscoverConditionSSJFP(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJRG(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return BUPPlayer.SSJRGAchieved;
            }

            public bool DiscoverConditionSSJRG(Player player)
            {
                return true;
            }

            public bool UnlockConditionPSSB(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && BUPPlayer.PSSBAchieved;

                //return player.GetModPlayer<GPlayer>().Trait != "Legendary" && (player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSBEBuff>()) >= 1 || player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSBKKBuff>()) >= 1);

                //return BUPPlayer.PSSBAchieved;
            }

            public bool DiscoverConditionPSSB(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSBE(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Prodigy" && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.PSSBBuff>()) >= 1; //&& BUPPlayer.SSBEAchieved;

                //return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
            }

            public bool DiscoverConditionSSBE(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSBKK(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Prodigy" && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.PSSBBuff>()) >= 1; //&& BUPPlayer.SSBKKAchieved;

                //return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Prodigy";
            }

            public bool DiscoverConditionSSBKK(Player player)
            {
                return true;
            }

        }
        */

        public class SEPBSSFPanel : TransformationTree
        {
            public override bool Complete() => true;

            public override bool Condition(Player player)
            {
                if (Config.Instance.SepTree)
                {
                    var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                    return true;
                }
                else { return false; }
            }

            //{
            //    var modPlayer = player.GetModPlayer<BUPPlayer>();
            //    
            //    return player.GetModPlayer<GPlayer>().Trait == "Prodigy"; //&& player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJB>()) >= 1;
            //    
            //    return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
            //}

            public override Connection[] Connections() => new Connection[]
            {
                new Connection(0.5f, 2, 1.5f, false, new Gradient(Color.DarkGoldenrod).AddStop(0.65f, new Color(247, 232, 31))),
                new Connection(2, 1, 2, true, new Gradient(Color.LawnGreen).AddStop(0.65f, new Color(240, 237, 126))),
                new Connection(2, 2, 1.5f, false, new Gradient(Color.Yellow).AddStop(0.65f, new Color(71, 164, 219))),
                new Connection(3.5f, 2, 3f, false, new Gradient(Color.Cyan).AddStop(0.65f, new Color(65,105,225))),
                new Connection(6.5f, 1, 2f, true, new Gradient(Color.Blue).AddStop(0.65f, new Color(0, 174, 152))),
            };

            public override string Name() => "Bonus Forms";
            
            public override Node[] Nodes() => new Node[]
            {
                //new Node(0, 0, "SSJ4Buff", "oozaru/Transformations/SSJ4Buff", ".",UnlockConditionFSSJ,DiscoverConditionFSSJ),
                new Node(0.5f, 2, "FSSJBuff", "SSBETES/Buffs/Transformations/FSSJBuff", "Fight with world evil so anger opens up new opportunities for you.",UnlockConditionFSSJ,DiscoverConditionFSSJ),
                new Node(2, 2, "SSJ1Buff", "DBZMODPORT/Buffs/SSJBuffs/SSJ1Buff", "Only through failure with a powerful foe will true power awaken.",UnlockConditionSSJ1,DiscoverConditionSSJ1),
                new Node(2, 1, "FPSSJBuff", "SSBETES/Buffs/Transformations/FPSSJBuff", "Master SSJ.",UnlockConditionFPSSJ,DiscoverConditionFPSSJ),
                new Node(2, 3, "SSJFPBuff", "SSBETES/Buffs/Transformations/SSJFPBuff", "Master SSJ.",UnlockConditionSSJFP,DiscoverConditionSSJFP),
                new Node(3.5f, 2, "SSJRGBuff", "SSBETES/Buffs/Transformations/SSJRGBuff", "Slime Queen and Cultist.",UnlockConditionSSJRG,DiscoverConditionSSJRG),
                new Node(5f, 2, "SSJBBuff", "DBZMODPORT/Buffs/SSJBuffs/SSJBBuff", "The experience from battling a galactic being could bring forth this strength..",UnlockConditionSSJB,DiscoverConditionSSJB),          
                new Node(6.5f, 2, "PSSBBuff", "SSBETES/Buffs/Transformations/PSSBBuff", "Perfect your strongest form.",UnlockConditionPSSB,DiscoverConditionPSSB),
                new Node(6.5f, 1, "SSBEBuff", "SSBETES/Buffs/Transformations/SSBEBuff", "Master your Perfected BLUE abilities.",UnlockConditionSSBE,DiscoverConditionSSBE), //Only gifted warriors can achieve such strength through training.
                new Node(6.5f, 3, "SSBKKBuff", "SSBETES/Buffs/Transformations/SSBKKBuff", "Master your Perfected BLUE abilities.",UnlockConditionSSBKK,DiscoverConditionSSBKK), //Train harder in your god form.
                new Node(3, 0, "IKARIBuff", "SSBETES/Buffs/Transformations/IKARIBuff", "Wall of Flesh.",UnlockConditionIKARI,DiscoverConditionIKARI), //Only gifted warriors can achieve such strength through training.
                new Node(4, 0, "EvilSaiyanBuff", "SSBETES/Buffs/Transformations/EvilSaiyanBuff", "Cthulhu creature may show your true power.",UnlockConditionEvilSaiyan,DiscoverConditionEvilSaiyan), //Train harder in your god form.
            };

            public bool UnlockConditionSSJ1(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<MyPlayer>().masteryLevel1 != 0;
            }

            public bool DiscoverConditionSSJ1(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin";
            }

            public bool UnlockConditionSSJB(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<MyPlayer>().masteryLevelBlue != 0;
            }

            public bool DiscoverConditionSSJB(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<MyPlayer>().masteryLevelGod != 0;
            }

            public bool UnlockConditionFSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.FSSJAchieved;
            }

            public bool DiscoverConditionFSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin";
            }

            public bool UnlockConditionIKARI(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary" && BUPPlayer.IKARIAchieved;
            }

            public bool DiscoverConditionIKARI(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary";
            }

            public bool UnlockConditionEvilSaiyan(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Ancient" && BUPPlayer.EvilSaiyanAchieved;
            }

            public bool DiscoverConditionEvilSaiyan(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Ancient";
            }

            public bool UnlockConditionFPSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary" && BUPPlayer.FPSSJAchieved;
            }

            public bool DiscoverConditionFPSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Legendary" && player.GetModPlayer<MyPlayer>().masteryLevel1 != 0;
            }

            public bool UnlockConditionSSJFP(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.SSJFPAchieved;
            }

            public bool DiscoverConditionSSJFP(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<MyPlayer>().masteryLevel1 != 0;
            }

            public bool UnlockConditionSSJRG(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.SSJRGAchieved;
            }

            public bool DiscoverConditionSSJRG(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.SSJRGAchieved;
            }

            public bool UnlockConditionPSSB(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.PSSBAchieved && player.GetModPlayer<MyPlayer>().masteryLevelBlue >= 0.9f;

                //return player.GetModPlayer<GPlayer>().Trait != "Legendary" && (player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSBEBuff>()) >= 1 || player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSBKKBuff>()) >= 1);

                //return BUPPlayer.PSSBAchieved;
            }

            public bool DiscoverConditionPSSB(Player player)
            {
                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<MyPlayer>().masteryLevelBlue != 0;
            }

            public bool UnlockConditionSSBE(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Buffs.Transformations.PSSBBuff>()) >= 1;
            }

            public bool DiscoverConditionSSBE(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.PSSBAchieved;
            }

            public bool UnlockConditionSSBKK(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Buffs.Transformations.PSSBBuff>()) >= 1;
            }

            public bool DiscoverConditionSSBKK(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "Majin" && BUPPlayer.PSSBAchieved;
            }

        }

        public class SUPERPanel : TransformationTree
        {
            public override bool Complete() => true;

            public override bool Condition(Player player)
            {
                var Modplayer = player.GetModPlayer<BUPPlayer>();
                return Modplayer.SSJ100Achieved && Modplayer.UBAchieved;
            }

            public override Connection[] Connections() => new Connection[]
            {
                //new Connection(5,4,0,false,new Gradient(Color.RoyalBlue).AddStop(0.60f, new Color(0, 0, 255))),
                //Color.RoyalBlue
                //new Connection(6,4,0,false,new Gradient(Color.Turquoise).AddStop(0.60f, new Color(0, 174, 152))),
            };

            public override string Name() => "BEST FORMS";

            public override Node[] Nodes() => new Node[]
            {
            new Node(2, 2, "UBBuff", "SSBETES/Buffs/Transformations/UBBuff", "Universal Root.", UnlockConditionUB, DiscoverConditionUB),
            new Node(5, 2, "SSJ100Buff", "SSBETES/Buffs/Transformations/SSJ100Buff", "Universal Root.", UnlockConditionSSJ100, DiscoverConditionSSJ100),
            };

            public bool UnlockConditionUB(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary" && BUPPlayer.UBAchieved;  //&& BUPPlayer.SSBEAchieved;

                //return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
            }

            public bool DiscoverConditionUB(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJ100(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return BUPPlayer.SSJ100Achieved;

                //return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
            }

            public bool DiscoverConditionSSJ100(Player player)
            {
                return true;
            }
        }

        public class TESTPanel : TransformationTree
        {

            public override bool Complete() => true;

            public override bool Condition(Player player)
            {

                var modPlayer = player.GetModPlayer<BUPPlayer>();

                return !player.HasBuff<TESTBuff>() && modPlayer.TESTAchieved;
                //var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                //return BUPPlayer.TESTAchieved;
                //return player.GetModPlayer<GPlayer>().Trait == "Legendary";
            }

            public override Connection[] Connections() => new Connection[]
            {
                new Connection(5,4,0,false,new Gradient(Color.RoyalBlue).AddStop(0.60f, new Color(0, 0, 255))),
                //Color.RoyalBlue
                new Connection(6,4,0,false,new Gradient(Color.Turquoise).AddStop(0.60f, new Color(0, 174, 152))),
            };

            public override string Name() => "TEST";

            public override Node[] Nodes() => new Node[]
            {
                new Node(3, 2, "TESTBuff", "SSBETES/Buffs/Transformations/TESTBuff", "Only gifted warriors can achieve such strength through training.",UnlockConditionTEST,DiscoverConditionTEST),
            };
            public bool UnlockConditionTEST(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return BUPPlayer.TESTAchieved;
            }

            public bool DiscoverConditionTEST(Player player)
            {
                return true;
            }
        }
    }
}


