using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using SSBETES.Assets;

namespace SSBETES.Buffs.Traits
{
    internal class AncientBuff : ModBuff
    {
 
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Evil Saiyan");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            // Description.SetDefault("Evil Ki overwhelms you...");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);
            player.statDefense += 5;
            //player.eyeColor = Color.Red;
        }
    }
}
