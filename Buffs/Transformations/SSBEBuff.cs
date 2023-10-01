using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using DBZMODPORT.Buffs;
using SSBETES.Assets;
using SSBETES.Changes;
using ReLogic.Content;

namespace SSBETES.Buffs.Transformations
{
    internal class SSBEBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/Aura/SSBEAuraN", 8, BlendState.AlphaBlend, new Color(171, 229, 255)); //44, 149, 197

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Buffs.Transformations.PSSBBuff>()) >= 1 && !player.HasBuff<SSBEBuff>(); //&& modPlayer.SSBEAchieved;

            //return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
        }

        public override string FormName() => "Super Saiyan Blue Evolution";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/SSBEHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(11, 63, 165)).AddStop(1f, new Color(49, 75, 152));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSBEActive = true;

            //ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSBEActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/FinalFlashFire", "DBZMODPORT/Sounds/SSB", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.RoyalBlue;

        public override void SetStaticDefaults()
        {
            kiDrainRate = 5.1f;
            kiDrainRateWithMastery = 2.7f;
            attackDrainMulti = 0.7f;

            if (ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 28;
                damageMulti = 1.90f;
                speedMulti = 1.35f;
            }
            else
            {
                baseDefenceBonus = 52;
                damageMulti = 5.45f;
                speedMulti = 5.35f;
            }

            base.SetStaticDefaults(); 
        }
    }
}
