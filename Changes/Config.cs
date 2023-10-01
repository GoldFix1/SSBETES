using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SSBETES.Changes
{
    /*
    internal class BalanceConfigServer
    {
        //public static object Instance { get; internal set; }

        // public override ConfigScope Mode => ConfigScope.ServerSide;

        //public static BalanceConfigServer Instance;

        //public bool SSJTweaks;


        
        internal static bool GetValue()
        {
            throw new NotImplementedException();
        }
        
    }
    */
    [Label("Server Settings")]
    internal class ConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static ConfigServer Instance;

        [Label("Rebalanced Stats (Mod Reload Required)")]
        [Tooltip("Self explanatory")]
        [DefaultValue(false)]
        public bool SSJTweaks;
    }

    [Label("Client Settings")]
    internal class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static Config Instance;

        [Label("Bonus forms on sepparate page")]
        [Tooltip("Self explanatory")]
        [DefaultValue(true)]
        public bool SepTree;

        [Label("Bonus forms on main page")]
        [Tooltip("Self explanatory")]
        [DefaultValue(false)]
        public bool NotSepTree;
    }
}