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
    internal class NewFormsItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("New Forms Unlock");
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
                BUPPlayer.BERSERKERAchieved = true;
                BUPPlayer.EvilSaiyanAchieved = true;
                BUPPlayer.UBAchieved = true;
                //BUPPlayer.SSJ100Achieved = true;
                //BUPPlayer.SSJRGAchieved = true;
                BUPPlayer.FPSSJAchieved = true;
                BUPPlayer.SSJFPAchieved = true;
        }
    }
}
