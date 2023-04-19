using Terraria;
using Terraria.ModLoader;
using DBZGoatLib;
using System;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework;
using Steamworks;
using SSBETES.Transformations;
using System.Security.Policy;
using Terraria.ModLoader.IO;
using DBZMODPORT.Buffs;
using DBZMODPORT;

namespace SSBETES.Assets
{
    internal class BUPPlayer : ModPlayer
    {
        public bool SSBEActive;
        public bool SSBEUnlockMsg;
        public bool SSBEAchieved;
    

        public bool SSBKKActive;
        public bool SSBKKUnlockMsg;
        public bool SSBKKAchieved;

        public bool FSSJActive;
        public bool FSSJUnlockMsg;
        public bool FSSJAchieved;

        public DateTime? Offset = null;
        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        private TransformationInfo? Form = null;

        public override void PostUpdate()
        {
            if (SSBEAchieved && !SSBEUnlockMsg)
            {
                SSBEUnlockMsg = true;
                Main.NewText("Your pride unlocked your true potential. Super Saiyan Blue Evolution has been achieved!");
            }

            if (SSBKKAchieved && !SSBKKUnlockMsg)
            {
                SSBKKUnlockMsg = true;
                Main.NewText("Now you are able to combine your god form with old techique!");
            }

            if (FSSJAchieved && !FSSJUnlockMsg)
            {
                FSSJUnlockMsg = true;
                Main.NewText("The anger fills your body!");
            }
        }


        public override void SaveData(TagCompound tag)
        {
            tag.Add("SSBETES_SSBEAchieved", SSBEAchieved);
            tag.Add("SSBETES_SSBEUnlockMsg", SSBEUnlockMsg);
            tag.Add("SSBETES_SSBKKAchieved", SSBKKAchieved);
            tag.Add("SSBETES_SSBKKUnlockMsg", SSBKKUnlockMsg);
            tag.Add("SSBETES_FSSJAchieved", FSSJAchieved);
            tag.Add("SSBETES_FSSJUnlockMsg", FSSJUnlockMsg);
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("SSBETES_SSBEAchieved"))
                SSBEAchieved = tag.GetBool("SSBETES_SSBEAchieved");
            if (tag.ContainsKey("SSBETES_SSBEUnlockMsg"))
                SSBEUnlockMsg = tag.GetBool("SSBETES_SSBEUnlockMsg");

            if (tag.ContainsKey("SSBETES_SSBKKAchieved"))
                SSBKKAchieved = tag.GetBool("SSBETES_SSBKKAchieved");
            if (tag.ContainsKey("SSBETES_SSBKKUnlockMsg"))
                SSBKKUnlockMsg = tag.GetBool("SSBETES_SSBKKUnlockMsg");
           
            if (tag.ContainsKey("SSBETES_FSSJAchieved"))
                FSSJAchieved = tag.GetBool("SSBETES_FSSJAchieved");
            if (tag.ContainsKey("SSBETES_FSSJUnlockMsg"))
                FSSJUnlockMsg = tag.GetBool("SSBETES_FSSJUnlockMsg");
        }

        public class BSSFPanel : TransformationTree
        {
            public override bool Complete() => false;

            public override bool Condition(Player player) => true;
            //{
            //    var modPlayer = player.GetModPlayer<BUPPlayer>();
            //    
            //    return player.GetModPlayer<GPlayer>().Trait == "Prodigy"; //&& player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJB>()) >= 1;
            //    
            //    return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
            //}

            public override Connection[] Connections() => new Connection[]
            {
            new Connection(6,1,0,false,new Gradient(Color.LightSkyBlue).AddStop(0.60f, new Color(0, 0, 255))),
            //Color.RoyalBlue
            //new Connection(7,1,1,false,new Gradient(Color.Turquoise).AddStop(0.60f, new Color(0, 174, 152))),
            };

            public override string Name() => "Bonus Forms";

            public override Node[] Nodes() => new Node[]
            {
            new Node(6, 1, "SSBEBuff", "SSBETES/Transformations/SSBEBuff", "Only gifted warriors can achieve such strength through training.",UnlockConditionSSBE,DiscoverConditionSSBE),
            new Node(7, 1, "SSBKKBuff", "SSBETES/Transformations/SSBKKBuff", "Train harder in your god form.",UnlockConditionSSBKK,DiscoverConditionSSBKK),
             new Node(0, 4, "FSSJBuff", "SSBETES/Transformations/FSSJBuff", "Incomplete anger opens this form.",UnlockConditionFSSJ,DiscoverConditionFSSJ),
            };
            public bool UnlockConditionSSBE(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait == "Prodigy";

                return BUPPlayer.SSBEAchieved;
            }

            public bool DiscoverConditionSSBE(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSBKK(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return player.GetModPlayer<GPlayer>().Trait != "Legendary";

                return BUPPlayer.SSBKKAchieved;
            }

            public bool DiscoverConditionSSBKK(Player player)
            {
                return true;
            }

            public bool UnlockConditionFSSJ(Player player)
            {
                var BUPPlayer = player.GetModPlayer<BUPPlayer>();

                return BUPPlayer.FSSJAchieved;
            }

            public bool DiscoverConditionFSSJ(Player player)
            {
                return true;
            }

        }
    }
}
    

