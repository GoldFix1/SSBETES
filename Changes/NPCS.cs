using System;
using System.Linq;
using System.Reflection;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria;
using DBZMODPORT;
using SSBETES.Items;
using SSBETES.Assets;
using SSBETES.Changes;

namespace SSBETES.Changes
{
    internal class NPCS : GlobalNPC
    {

        public override void OnKill(NPC npc)
        {
            base.OnKill(npc);
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                if (npc.type == NPCID.WallofFlesh)
                {
                    BUPPlayer player = Main.CurrentPlayer.GetModPlayer<BUPPlayer>();
                    if (!player.IKARIAchieved)
                    {
                        player.Unlocking = true;
                        return;
                    }
                }
            }
            else if (npc.type == NPCID.WallofFlesh)
            {
                for (int i = 0; i < 255; i++)
                {
                    BUPPlayer player2 = Main.player[i].GetModPlayer<BUPPlayer>();
                    if (!player2.IKARIAchieved)
                    {
                        NetworkHandler.SendUnlockStatus(player2.Player.whoAmI, true);
                    }
                }
            }
        }


        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.MoonLordCore)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSBEItem>(), 1, 0, 1));
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSBKKItem>(), 1, -1 , 1));
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.TestItems.PSSBItem>(), 1, 0, 1));
            }

            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.TestItems.EvilSaiyanItem>(), 1, 1, 1));
            }

            if (npc.type == NPCID.WallofFlesh)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.IKARIItem>(), 1, 0, 1));
            }
        }
               
    }
}
