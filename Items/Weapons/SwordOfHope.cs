using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using SSBETES.Changes;
using SSBETES.Assets;
using SSBETES.Items;

namespace SSBETES.Items.Weapons
{
	public class SwordOfHope : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Of Hope"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Probably contains a huge power");
		}
		public override void SetDefaults()
		{
			Item.damage = 81;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			//Item.shoot = ProjectileID.EnchantedBeam;
			//Item.shootSpeed = 10f;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.BrokenArmor, 600);
        }
		/*
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.HallowedBar, 20);
            recipe1.AddIngredient(ItemID.PlatinumBar, 10);
            recipe1.AddIngredient(ItemID.HellstoneBar, 15);
            recipe1.AddIngredient(ItemID.SoulofSight, 5);
            recipe1.AddIngredient(ItemID.SoulofMight, 5);
            recipe1.AddIngredient(ItemID.SoulofFright, 5);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
		*/
	}
}