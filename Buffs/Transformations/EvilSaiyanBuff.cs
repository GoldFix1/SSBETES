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
    internal class EvilSaiyanBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/Aura/EvilAura", 4, BlendState.AlphaBlend, new Color(122, 0, 7));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<EvilSaiyanBuff>() && modPlayer.EvilSaiyanAchieved;
        }

        public override string FormName() => "Evil Saiyan";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/EvilSaiyanHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(50, 3, 3)).AddStop(1f, new Color(110, 0, 0));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().EvilSaiyanActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().EvilSaiyanActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ2", 260);

        public override bool Stackable() => true;

        public override Color TextColor() => Color.DarkRed;

        public override void SetStaticDefaults()
        {
            kiDrainRate = 0.5f;
            kiDrainRateWithMastery = 0f;
            attackDrainMulti = 0f;

            if (ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 2;
                damageMulti = 1.15f;
                speedMulti = 1.05f;
                if(NPC.downedBoss3)
                {
                    baseDefenceBonus = 5;
                    damageMulti = 1.20f;
                    speedMulti = 1.10f;
                    if(NPC.downedPlantBoss)
                    {
                        baseDefenceBonus = 8;
                        damageMulti = 1.30f;
                        speedMulti = 1.15f;
                        if(NPC.downedMoonlord)
                        {
                            baseDefenceBonus = 13;
                            damageMulti = 1.45f;
                            speedMulti = 1.15f;
                        }
                    }
                }
            }
            else
            {
                baseDefenceBonus = 4;
                damageMulti = 1.30f;
                speedMulti = 1.05f;
                if (NPC.downedBoss3)
                {
                    baseDefenceBonus = 6;
                    damageMulti = 1.30f;
                    speedMulti = 1.10f;
                    if (NPC.downedPlantBoss)
                    {
                        baseDefenceBonus = 8;
                        damageMulti = 1.45f;
                        speedMulti = 1.25f;
                        if (NPC.downedMoonlord)
                        {
                            baseDefenceBonus = 15;
                            damageMulti = 1.65f;
                            speedMulti = 1.35f;
                        }
                    }
                }
            }

            base.SetStaticDefaults(); 
        }
    }
}
