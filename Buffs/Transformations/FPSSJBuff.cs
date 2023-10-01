using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using SSBETES.Assets;
using SSBETES.Changes;

namespace SSBETES.Buffs.Transformations
{
    internal class FPSSJBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("DBZMODPORT/Effects/Animations/Aura/LSSJAura", 4, BlendState.Additive, new Color(66, 225, 58));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<FPSSJBuff>() && modPlayer.FPSSJAchieved;
        }

        public override string FormName() => "Full Power Super Saiyan";

        public override string HairTexturePath() => "DBZMODPORT/Hairs/LSSJ/LSSJHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(251, 255, 48)).AddStop(1f, new Color(66, 225, 58));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().FPSSJActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().FPSSJActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJAura", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Lime;

        public override void SetStaticDefaults()
        {
            kiDrainRate = 1.5f;
            kiDrainRateWithMastery = 0.7f;
            attackDrainMulti = 0.10f;

            if (!ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 9;
                damageMulti = 2.35f;
                speedMulti = 2.15f;
            }
            else
            {
                baseDefenceBonus = 13;
                damageMulti = 1.40f;
                speedMulti = 1.35f;
            }

            base.SetStaticDefaults(); 
        }
    }
}
