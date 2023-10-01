using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using DBZMODPORT;
using DBZGoatLib.Model;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using SSBETES.Assets;

namespace SSBETES.Buffs.Traits
{
    public class MajinTrait : Trait
    {
        public override Gradient KiBarGradient()
        {
            Gradient gradient = new Gradient(Color.HotPink);
            gradient.AddStop(0.75f, Color.DeepPink);

            return gradient;
        }

        public override string Name() => "Majin";

        public override void OnLoseTrait(Player player)
        {
            player.GetModPlayer<BUPPlayer>().isMajin = false;
            player.ClearBuff(ModContent.BuffType<UnknownMajin>());
            player.ClearBuff(ModContent.BuffType<MajinBuff>());
        }

        public override void OnTrait(Player player)
        {
            player.GetModPlayer<BUPPlayer>().isMajin = true;
        }

        public override float Weight() => 0.0000004f;

        TraitInfo majin => new TraitInfo(Name(), Weight(), KiBarGradient(), OnTrait, OnLoseTrait);
    }
}
