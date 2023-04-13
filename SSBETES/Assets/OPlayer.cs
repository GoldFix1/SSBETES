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

namespace SSBETES.Assets
{
    internal class OPlayer : ModPlayer
    {
        public bool SSBEActive;
        public bool SSBEUnlockMsg;
        public bool SSBEAchieved;

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

        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SSBETES_SSBEAchieved", SSBEAchieved);
            tag.Add("SSBETES_SSBEUnlockMsg", SSBEUnlockMsg);
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("SSBETES_SSBEAchieved"))
                SSBEAchieved = tag.GetBool("SSBETES_SSBEAchieved");
            if (tag.ContainsKey("SSBETES_SSBEUnlockMsg"))
                SSBEUnlockMsg = tag.GetBool("SSBETES_SSBEUnlockMsg");
        }

        public class BSSFPanel : TransformationTree
        {
            public override bool Complete() => true;

            public override bool Condition(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
            }

            public override Connection[] Connections() => new Connection[]
            {
            new Connection(0,2,1,false,new Gradient(Color.RoyalBlue).AddStop(0.60f, new Color(0, 0, 255))),
            };

            public override string Name() => "Bonus Forms";

            public override Node[] Nodes() => new Node[]
            {
            new Node(0, 2, "SSBEBuff", "SSBETES/Transformations/SSBEBuff", "Train harder in your god form",UnlockConditionSSBE,DiscoverConditionSSBE),
            };
            public bool UnlockConditionSSBE(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSBEAchieved;
            }

            public bool DiscoverConditionSSBE(Player player)
            {
                return true;
            }


        }
    }
}
