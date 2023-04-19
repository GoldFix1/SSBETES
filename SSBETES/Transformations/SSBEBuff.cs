using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
using SSBETES.Assets;

namespace SSBETES.Transformations
{
    internal class SSBEBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/SSBEAuraN", 8, BlendState.AlphaBlend, new Color(44, 149, 197));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
        }

        public override string FormName() => "Super Saiyan Blue Evolution";

        public override string HairTexturePath() => "SSBETES/Assets/SSBEHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(11, 63, 165)).AddStop(1f, new Color(49, 75, 152));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSBEActive = true;
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
            damageMulti = 5.2f;
            speedMulti = 4.0f;

            kiDrainRate = 5.0f;
            kiDrainRateWithMastery = 2.4f;

            attackDrainMulti = 0.7f;
            baseDefenceBonus = 41;

            base.SetStaticDefaults(); 
        }
    }
}
