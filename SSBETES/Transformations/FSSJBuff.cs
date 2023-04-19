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
    internal class FSSJBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/FSSJAura", 4, BlendState.Additive, new Color(178, 118, 0));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<FSSJBuff>() && modPlayer.FSSJAchieved;
        }

        public override string FormName() => "False Super Saiyan";

        public override string HairTexturePath() => "SSBETES/Assets/FSSJHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(50, 45, 3)).AddStop(1f, new Color(156, 107, 28));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().FSSJActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().FSSJActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/KaioAuraAscend", "DBZMODPORT/Sounds/SSJAura", 260);

        public override bool Stackable() => true;

        public override Color TextColor() => Color.Goldenrod;

        public override void SetStaticDefaults()
        {
            damageMulti = 1.35f;
            speedMulti = 1.35f;

            kiDrainRate = 1.2f;
            kiDrainRateWithMastery = 0.7f;

            attackDrainMulti = 0.3f;
            baseDefenceBonus = 2;

            base.SetStaticDefaults(); 
        }
    }
}
