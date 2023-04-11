using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSBETES.Items
{
    public class SSBETest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("DEUBG ITEM\bUnlocks Super Saiyan Blue Evolution.");
            DisplayName.SetDefault("SSBE Test");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Item.type] = 1;
        }
        public override void SetDefaults()
        {
            Item.color = new Color(0xC0, 0xC0, 0xCF);
            Item.width = 32;
            Item.height = 32;
            Item.value = 40001;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.defense = 0;
            Item.consumable = true;
        }
        public override bool ConsumeItem(Player player)
        {
            return true;
        }
        public override void OnConsumeItem(Player player)
        {
            player.GetModPlayer<BPlayer>().SSBEAchieved = true;
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<BPlayer>().SSBEAchieved = true;
            return true;
        }
    }
}
