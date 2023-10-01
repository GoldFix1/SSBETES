using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using SSBETES.Assets;

namespace SSBETES.Items.TestItems
{
    internal class FSSJItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("False Super Saiyan UNLOCK");
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
            Item.rare = ItemRarityID.Orange;
        }

        public override bool? UseItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            return !BUPPlayer.FSSJAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var BUPPlayer = player.GetModPlayer<BUPPlayer>();
            if (!BUPPlayer.FSSJAchieved)
            {
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDustPerfect(player.Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-(float)player.width - 10), (float)(player.width + 10)), Utils.NextFloat(Main.rand, (float)(-(float)player.height - 10), (float)(player.height + 10))), 108,
                    new Vector2?(Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(100f))), 0, default(Color), 1f).noGravity = true;
                }
                BUPPlayer.FSSJAchieved = true;
            }
        }
    }
}
