using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using SSBETES.Assets;
using DBZMODPORT;

namespace SSBETES.Items.TestItems
{
    internal class SSBKKItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Saiyan Blue Kaio-Ken UNLOCK");
            // Tooltip.SetDefault("Unleashes new power");
            // Tooltip.SetDefault("");
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
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.scale = 1f;
            Item.rare = 9;
        }

        public override bool? UseItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            return !BUPPlayer.SSBKKAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            if (!BUPPlayer.SSBKKAchieved)
            {
                BUPPlayer.SSBKKAchieved = true;
            }
        }
    }
}
