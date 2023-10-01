using System;
using DBZMODPORT;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace SSBETES
{
    public abstract class ReforgeFixKiItem : KiItem
    {
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            Mod DBZmod = ModLoader.GetMod("DBZMODPORT");
            WeightedRandom<int> weightedRandom = new WeightedRandom<int>();
            weightedRandom.Add(DBZmod.Find<ModPrefix>("BalancedPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("CondensedPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("MystifyingPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("UnstablePrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("FlawedPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("BoostedPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("NegatedPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("OutrageousPrefix").Type, 3.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("PoweredPrefix").Type, 2.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("FlashyPrefix").Type, 2.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("InfusedPrefix").Type, 2.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("DistractedPrefix").Type, 2.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("DestructivePrefix").Type, 2.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("MasteredPrefix").Type, 1.0);
            weightedRandom.Add(DBZmod.Find<ModPrefix>("TranscendedPrefix").Type, 1.0);
            int choice = weightedRandom;
            if (base.Item.damage > 0 && base.Item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }
    }
}
