﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using SSBETES.Assets;
//using DBTBalance;
//using DBTBalance.Buffs;
//using DBTBalance.Helpers;
//using DBTBalance.Model;

namespace SSBETES.Buffs.Transformations
{
    internal class ConBERSERKERBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/TESTAura", 4, BlendState.Additive, new Color(178, 118, 0));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<BERSERKERBuff>() && modPlayer.BERSERKERAchieved;
        }

        public override string FormName() => "Controlled Berserk";

        public override string HairTexturePath() => "SSBETES/Assets/BLANKHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(50, 45, 3)).AddStop(1f, new Color(156, 107, 28));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().BERSERKERActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().BERSERKERActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/KaioAuraAscend", "DBZMODPORT/Sounds/SSJAura", 260);

        public override bool Stackable() => true;

        public override Color TextColor() => Color.Goldenrod;

        public override void SetStaticDefaults()
        {
            kiDrainRate = -10f;
            kiDrainRateWithMastery = -100f;
            attackDrainMulti = 0f;

//            if (BalanceConfigServer.Instance.SSJTweaks)
//            {
//                baseDefenceBonus = 2;
//                damageMulti = 1.15f;
//                speedMulti = 1.05f;
//            }
//            else
//            {
                baseDefenceBonus = 99;
                damageMulti = 9f;
                speedMulti = 9f;
//            }

            base.SetStaticDefaults(); 
        }
    }
}