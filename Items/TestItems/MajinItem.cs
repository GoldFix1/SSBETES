using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using DBZGoatLib.Model;
using SSBETES.Assets;
//using TraitsPlus;

namespace SSBETES.Items.TestItems
{
    internal class MajinItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Majin Test Item");
            // Tooltip.SetDefault("Gives the majin trait");
        }

        public override void SetDefaults()
        {
            Item.consumable = false;
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
            TraitInfo? old = TraitHandler.GetTraitByName(player.GetModPlayer<GPlayer>().Trait);
            if (old != null)
            {
                old.GetValueOrDefault().IfUntrait(player);
            }
            TraitInfo? majin = TraitHandler.GetTraitByName("Majin");
            if (majin != null)
            {
                majin.GetValueOrDefault().IfTrait(player);
            }
            player.GetModPlayer<GPlayer>().Trait = "Majin";
            return new bool?(true);
        }
    }
}
