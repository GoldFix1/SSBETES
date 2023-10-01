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
    internal class IKARIBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/Aura/IKARIAura", 4, BlendState.Additive, new Color(79, 234, 32));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<IKARIBuff>() && modPlayer.IKARIAchieved;
        }

        public override string FormName() => "Wrathful";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/IKARIHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(50, 205, 50)).AddStop(1f, new Color(173, 255, 47));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().IKARIActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().IKARIActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/Explosion", "DBZMODPORT/Sounds/SSJAura", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.LimeGreen;

        public override void SetStaticDefaults()
        {
            kiDrainRate = 1.25f;
            kiDrainRateWithMastery = 0.3f;
            attackDrainMulti = 0.7f;

            if (ConfigServer.Instance.SSJTweaks)
            {
                if (!NPC.downedPlantBoss)
                {
                    baseDefenceBonus = 7;
                    damageMulti = 1.45f;
                    speedMulti = 1.70f;
                }
                else
                {
                    baseDefenceBonus = 12;
                    damageMulti = 1.70f;
                    speedMulti = 2.05f;
                }
            }
            else
            {
                if(!NPC.downedPlantBoss)
                {
                    baseDefenceBonus = 9;
                    damageMulti = 1.70f;
                    speedMulti = 2.05f;
                }
                else
                {
                    baseDefenceBonus = 15;
                    damageMulti = 2.20f;
                    speedMulti = 2.55f;
                }
                base.SetStaticDefaults();
            }

            //base.Description.SetDefault("\nThe more you are in this form, the more dangerous you become.");
        }

    }
}
