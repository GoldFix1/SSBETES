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
    internal class SSBKKBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/Aura/SSBKKAura", 4, BlendState.AlphaBlend, new Color(255, 255, 255)); //7, 166, 182

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Buffs.Transformations.PSSBBuff>()) >= 1 && (player.GetModPlayer<GPlayer>().Trait != "Legendary" && player.GetModPlayer<GPlayer>().Trait != "Ancient" && player.GetModPlayer<GPlayer>().Trait != "GOD" && player.GetModPlayer<GPlayer>().Trait != "Primal" && player.GetModPlayer<GPlayer>().Trait != "Majin") && !player.HasBuff<SSBKKBuff>() && modPlayer.SSBKKAchieved;

            //return !player.HasBuff<SSBKKBuff>() && modPlayer.SSBKKAchieved;
        }

        public override string FormName() => "Super Saiyan Blue Kaio-Ken";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/SSBKKHair";

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
            kiDrainRate = 4.4f;
            kiDrainRateWithMastery = 2.2f;
            attackDrainMulti = 0.45f;
            
            if (ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 28;
                damageMulti = 1.95f;
                speedMulti = 1.35f;
            }
            else
            {
                baseDefenceBonus = 47;
                damageMulti = 5.8f;
                speedMulti = 5.55f;
            }
            base.SetStaticDefaults();
            //base.Description.SetDefault("\nConsumes health in exchange for strength.");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 23;
            base.Update(player, ref buffIndex);

            base.SetStaticDefaults();
        }
    }
}
