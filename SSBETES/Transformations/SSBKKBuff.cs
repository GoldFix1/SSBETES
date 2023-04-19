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
    internal class SSBKKBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/SSBKKAura", 4, BlendState.Additive, new Color(7, 166, 182));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<SSBKKBuff>() && modPlayer.SSBKKAchieved;
        }

        public override string FormName() => "Super Saiyan Blue Kaio-Ken";

        public override string HairTexturePath() => "SSBETES/Assets/SSBKKHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(51, 155, 155)).AddStop(1f, new Color(229, 34, 59));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSBKKActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSBKKActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/KaioAuraAscend", "DBZMODPORT/Sounds/SSJR", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Turquoise;

        public override void SetStaticDefaults()
        {
            damageMulti = 5.4f;
            speedMulti = 4.0f;

            kiDrainRate = 5.0f;
            kiDrainRateWithMastery = 2.6f;

            attackDrainMulti = 0.8f;
            baseDefenceBonus = 41;

            base.SetStaticDefaults(); 
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 17;
            base.Update(player, ref buffIndex);

            base.SetStaticDefaults();
        }
    }
}
