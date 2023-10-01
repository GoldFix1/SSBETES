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
    internal class SSJFPBuff : Transformation
    {
        public override AuraData AuraData()
        {
            return default(AuraData);
        }

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<SSJFPBuff>() && modPlayer.SSJFPAchieved;
        }

        public override string FormName() => "Super Saiyan Full Power";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/SSJFPHair";

        public override Gradient KiBarGradient() => new Gradient(Color.Gold).AddStop(1f, Color.Gold);

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSJFPActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().SSJFPActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/PowerDown", "SSBETES/Sounds/BLANK", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.BlanchedAlmond;

        public override void SetStaticDefaults()
        {
            kiDrainRate = 0f;
            kiDrainRateWithMastery = 0f;
            attackDrainMulti = 0.15f;

            if (!ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 5;
                damageMulti = 1.60f;
                speedMulti = 1.60f;
            }
            else
            {
                baseDefenceBonus = 5;
                damageMulti = 1.25f;
                speedMulti = 1.15f;
            }

            base.SetStaticDefaults(); 
        }
    }
}
