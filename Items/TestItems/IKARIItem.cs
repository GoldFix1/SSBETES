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
    internal class IKARIItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ikari UNLOCK");
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
            Item.rare = 2;
        }

       // public override bool? UseItem(Player player)
       // {
       //     var GPlayer = player.GetModPlayer<GPlayer>();
       //     return GPlayer.SSBAchieved;
       // }

        public override bool? UseItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            return !BUPPlayer.IKARIAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            if (!BUPPlayer.IKARIAchieved)
            {
                BUPPlayer.IKARIAchieved = true;
            }
        }
    }
}
