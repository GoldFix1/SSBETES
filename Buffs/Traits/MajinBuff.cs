using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using DBZMODPORT;
using SSBETES.Assets;

namespace SSBETES.Buffs.Traits
{
    internal class MajinBuff : ModBuff
    {
 
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Majin");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            // Description.SetDefault("Why are you pink?");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);
            //player.skinColor = Color.HotPink;
            player.statLifeMax2 += 150;
            player.GetModPlayer<MyPlayer>().kiMax2 += 1500;
        }
    }
}
