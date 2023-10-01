using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using SSBETES.Assets;
//using TraitsPlus;

namespace SSBETES.Items.TestItems
{
    internal class FPSSJItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Full Power SSJ Unlock");
            // Tooltip.SetDefault("---");
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.potion = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.scale = 1f;
            Item.rare = -13;
        }
    public override bool? UseItem(Player player)
        {
            return true;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
                BUPPlayer.FPSSJAchieved = true;
        }
    }
}
