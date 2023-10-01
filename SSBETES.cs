using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using DBZGoatLib.Model;
using System;
using System.IO;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;
using SSBETES.Assets;
using SSBETES.Changes;
using SSBETES.Buffs.Traits;
using SSBETES.Buffs.Transformations;
using DBZMODPORT;
using DBZMODPORT.Effects;

namespace SSBETES
{
	public class SSBETES : Mod
	{
        //public static SSBETES Instance;
        //public static Mod DBTBalance;
        public static DBZMODPORT.Effects.CircleShader circle;
        public static Mod Instance;
        public static Mod DBZMOD;
        public static Mod OOZARU;
        public static Mod GOATLIB;

        public TraitInfo Anc => TraitHandler.GetTraitByName("ancient").GetValueOrDefault();
        public TraitInfo Maj => TraitHandler.GetTraitByName("majin").GetValueOrDefault();

        public override void Load()
        {
            SSBETES.Instance = this;
            TraitHandler.RegisterTrait(Anc);
            TraitHandler.RegisterTrait(Maj);

            BUPPlayer.PowerUp = KeybindLoader.RegisterKeybind(SSBETES.Instance, "Power Up (SSBE Mod)", "Z"); //(Microsoft.Xna.Framework.Input.Keys)76
            BUPPlayer.Ability = KeybindLoader.RegisterKeybind(SSBETES.Instance, "Ability", "P");

            if (ModLoader.TryGetMod("DBZMODPORT", out Mod dbz))
            {
                DBZMOD = dbz;
            }
            if (ModLoader.TryGetMod("oozaru", out Mod ooz))
            {
                OOZARU = ooz;
            }
            if (ModLoader.TryGetMod("DBZGoatLib", out Mod goat))
            {
                GOATLIB = goat;
            }
        }

        public override void Unload()
        {
            SSBETES.Instance = null;
            TraitHandler.UnregisterTrait(Anc);
            TraitHandler.UnregisterTrait(Maj);

            //Instance = null;
            DBZMOD = null;
            GOATLIB = null;
            OOZARU = null;
            SSBETES.DBZMOD = null;
            BUPPlayer.PowerUp = null;
            BUPPlayer.Ability = null;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            base.HandlePacket(reader, whoAmI);
            NetworkHandler.HandlePacket(reader, whoAmI);
        }
    }
}