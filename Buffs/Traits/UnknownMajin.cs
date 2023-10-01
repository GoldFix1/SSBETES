using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using SSBETES.Assets;

namespace SSBETES.Buffs.Traits
{
    internal class UnknownMajin : ModBuff
    {
 
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("???");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            // Description.SetDefault("You're not like the others...");
        }

    }
}
