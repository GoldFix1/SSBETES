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
    internal class EvilSaiyanItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fruit of Might");
            // Tooltip.SetDefault("Unlock Evil Form if you have ancient trait");
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
            Item.rare = ItemRarityID.LightPurple;
        }
    public override bool? UseItem(Player player)
        {
            return true;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
                BUPPlayer.EvilSaiyanAchieved = true;
        }
    }
}
