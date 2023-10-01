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
    internal class BERSERKERBuff : Transformation
    {
        public override AuraData AuraData()
        {
            return new AuraData("DBZGoatLib/Assets/BaseAura", 4, BlendState.AlphaBlend, new Color(22, 14, 24, 200));
        }

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BUPPlayer>();

            return !player.HasBuff<BERSERKERBuff>() && modPlayer.BERSERKERAchieved;
        }
        
        public override string FormName()
        {
            return "Berserk";
        }

        public override string HairTexturePath()
        {
            return string.Empty;
        }

        public override Gradient KiBarGradient()
        {
            return null;
        }

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().BERSERKERActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<BUPPlayer>().BERSERKERActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData()
        {
            return default(SoundData);
        }

        public override bool Stackable() => true;

        public override Color TextColor() => new Color(43, 33, 45);

        public override void SetStaticDefaults()
        {
            if (ConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 4;
                damageMulti = 1.15f;
                speedMulti = 1.10f;
            }
            else
            {
                baseDefenceBonus = 7;
                damageMulti = 1.40f;
                speedMulti = 1.30f;
            }

            base.SetStaticDefaults(); 
        }
    }
}
