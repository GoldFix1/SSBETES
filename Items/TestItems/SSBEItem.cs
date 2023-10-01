using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using SSBETES.Assets;

namespace SSBETES.Items.TestItems
{
    internal class SSBEItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Saiyan Blue Evolution UNLOCK");
            // Tooltip.SetDefault("Unleashes new power");
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
            Item.rare = 9;
        }

        public override bool? UseItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            return !BUPPlayer.SSBEAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            if (!BUPPlayer.SSBEAchieved)
            {
                BUPPlayer.SSBEAchieved = true;
            }
        }
    }
}
