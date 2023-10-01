using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using DBZMODPORT;
using DBZMODPORT.Buffs.SSJBuffs;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using SSBETES.Assets;
using SSBETES.Changes;
using SSBETES.Buffs.Traits;
using Terraria.ID;
using System.Runtime.CompilerServices;

namespace SSBETES.Buffs.Transformations
{
    internal class PSSBBuff : Transformation
    {
        public override AuraData AuraData()
        {
            return default(AuraData);
        }

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<PSSBBuff>() && modPlayer.PSSBAchieved && player.GetModPlayer<MyPlayer>().masteryLevelBlue >= 1;
        }

        public override string FormName() => "Perfected Super Saiyan Blue";

        public override string HairTexturePath() => "SSBETES/Assets/Hair/PSSBHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(87, 214, 214)).AddStop(1f, new Color(87, 214, 214));

        public override void OnTransform(Player player)
        {
            player.ClearBuff(ModContent.BuffType<SSJBBuff>());
            player.GetModPlayer<BUPPlayer>().PSSBActive = true;

            for (int i = 0; i < 65; i++)
            {
                Lighting.AddLight(player.Center, Color.Blue.ToVector3());
                int dust1 = Dust.NewDust(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 4), (float)(player.width + 2)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 4), (float)(player.height + 8))),
                1, 1, DustID.Confetti, player.velocity.X + (float)(Random.Shared.NextDouble() * 2.0 - 1.0), player.velocity.Y + (float)(Random.Shared.NextDouble() * 2.0 - 1.0),
                90, new Color(133, 242, 242), 1.3f);   //Color.DeepSkyBlue  new Color(133, 242, 242)
                Main.dust[dust1].noGravity = true;
            }                
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().PSSBActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSB", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Aqua;

        //Dust.NewDustPerfect(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 5), (float)(player.width + 5)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 5), (float)(player.height + 5))), 40, new Vector2?(Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(50f))), 0, Color.DodgerBlue, 1f).noGravity = true; //looks like grass while powering up

        public override void SetStaticDefaults()
        {
            kiDrainRate = 1.40f;
            kiDrainRateWithMastery = 1.40f;
            attackDrainMulti = 0.55f;

            if (ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 32;
                damageMulti = 1.75f;
                speedMulti = 1.35f;
            }
            else
            {
                baseDefenceBonus = 44;
                damageMulti = 4.9f;
                speedMulti = 4.9f;
            }
            //Description.SetDefault("\nSlightly increased health regen.");
            base.SetStaticDefaults();
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            Description.SetDefault("\nSlightly increased health regen.");
            base.SetStaticDefaults();
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            base.Update(player, ref buffIndex);

            base.SetStaticDefaults();
        }
    }
}
