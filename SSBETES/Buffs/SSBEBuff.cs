using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSBETES.Helpers;
using SSBETES.Model;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using Microsoft.Xna.Framework.Graphics;

namespace SSBETES.Buffs
{
    public class SSBEBuff : Transformation
    {
        public override void SetStaticDefaults()
        {
            kiDrainRate = 5.0f;
            kiDrainRateWithMastery = 2.0f;
            attackDrainMulti = 1.9f;

            if (BalanceConfigServer.Instance.SSJTweaks)
            {
                damageMulti = 1.85f;
                speedMulti = 0.9f;
                baseDefenceBonus = 31;
            }
            else
            {
                damageMulti = 5.1f;
                speedMulti = 3.6f;
                baseDefenceBonus = 51;
            }
            base.SetStaticDefaults();
        }

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<BPlayer>();
            bool isProdigy = player.GetModPlayer<GPlayer>().Trait == "Prodigy";

            return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved && isProdigy;
# return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved && player.GetModPlayer<GPlayer>().Trait == "Prodigy";
        }

        public override void OnTransform(Player player) => 
            player.GetModPlayer<BPlayer>().SSBEActive = true;
        public override void PostTransform(Player player) =>
            player.GetModPlayer<BPlayer>().SSBEActive = false;

        public override string FormName() => "Super Saiyan Blue Evolution";

        public override bool Stackable() => false;

        public override Color TextColor() => Color.RoyalBlue;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);
        public override AuraData AuraData() => new AuraData("SSBETES/Assets/SSBEAura", 4, BlendState.AlphaBlend, new Color(250, 74, 67));
        public override Gradient KiBarGradient() => new Gradient(new Color(11, 63, 165)).AddStop(1f, new Color(20, 47, 127));

        public override string HairTexturePath() => "SSBETES/Assets/SSBEHair";

        public override bool SaiyanSparks() => true;

    }

# public class SSBEPanel : TransformationTree
#    {
# public override bool Complete() => false;
#
# public override Connection[] Connections() => new Connection[]
#        {
# new Connection(3,3,1,false,new Gradient(Color.LightGreen).AddStop(0.60f, new Color(255, 56, 99)))
#        };
#
# public override string Name() => "SSJ Partial Tree";
#
# public override Node[] Nodes() => new Node[]
#        {
# new Node(4,3,"SSBEBuff","SSBETES/Buffs/SSBEBuff","After defeating what gave you power, you will become stronger.",UnlockCondition,DiscoverCondition)
#        };
#
# public bool UnlockCondition(Player player)
#        {
# return player.GetModPlayer<BPlayer>().SSBEAchieved && player.GetModPlayer<GPlayer>().Trait == "Prodigy";
#}
# public bool DiscoverCondition(Player player)
#        {
# return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
#}
# public override bool Condition(Player player) => true;
#}
#}
