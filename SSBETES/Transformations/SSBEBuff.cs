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
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/SSBEAura", 4, BlendState.AlphaBlend, new Color(250, 74, 67));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
        }

        public override string FormName() => "Super Saiyan Blue Evolution";

        public override string HairTexturePath() => "SSBETES/Assets/SSBEHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(11, 63, 165)).AddStop(1f, new Color(20, 47, 127));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSBEActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSBEActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.RoyalBlue;

        public override void SetStaticDefaults()
        {
            damageMulti = 5.1f;
            speedMulti = 3.6f;

            kiDrainRate = 5.0f;
            kiDrainRateWithMastery = 2.0f;

            attackDrainMulti = 1.9f;
            baseDefenceBonus = 51;

            base.SetStaticDefaults(); 
        }
    }
}
