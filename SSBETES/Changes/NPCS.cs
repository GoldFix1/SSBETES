using System;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria;
using SSBETES.Items;

namespace SSBETES.Changes
{
    internal class NPCS : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSBEItem>(), 1, 0, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSBKKItem>(), 1, -1 , 1));
            }

            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FSSJItem>(), 1, 0, 1));
            }
        }
    }
}
