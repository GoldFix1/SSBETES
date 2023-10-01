using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace SSBETES.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    internal class CrimsonMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Dont draw head
            //ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Example: Wizards Hat
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Example: Masks
            //ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
            //ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(gold: 35);
            Item.rare = ItemRarityID.Red;

            Item.defense = 10;
        }

        public override void AddRecipes()
        {
            Mod DBT = ModLoader.GetMod("DBZMODPORT");
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.PinkDye);
            recipe.AddIngredient(ItemID.VioletGradientDye);
            recipe.AddIngredient(ItemID.PinkandBlackDye);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(DBT.Find<ModTile>("KaiTable"));
            recipe.Register();
        }
    }
}