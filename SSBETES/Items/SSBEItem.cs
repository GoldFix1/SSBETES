using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using SSBETES.Assets;

namespace SSBETES.Items
{
    internal class SSBEItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BEvolution Test");
            Tooltip.SetDefault("Ok");
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
        }

        public override bool? UseItem(Player player)
        {
            var oplayer = player.GetModPlayer<OPlayer>();
            return !oplayer.SSBEAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var oplayer = player.GetModPlayer<OPlayer>();
            if (!oplayer.SSBEAchieved)
            {
                oplayer.SSBEAchieved = true;
            }
        }
    }
}
