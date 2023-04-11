using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using Terraria;
using System.Dynamic;
using SSBETES.Buffs;
using SSBETES.Helpers;
using System.IO;
using DBZGoatLib;
using SSBETES.Model;
using Terraria.ModLoader.Config;

namespace SSBETES
{
	public class SSBETES : Mod
	{
		public static SSBETES Instance;
        public static Mod DBZMOD;
        public static Mod DBCA;
        public static Mod GOATLIB;

        public const BindingFlags flagsAll = BindingFlags.Public | BindingFlags.NonPublic
        | BindingFlags.Instance | BindingFlags.Static | BindingFlags.GetField
        | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty;

        internal static List<Detour> Detours = new List<Detour>();
        internal static List<Hook> Hooks = new List<Hook>();

        public override void Load()
        {
            Instance = this;
            MonoModHooks.RequestNativeAccess();

            if (ModLoader.TryGetMod("DBZGoatLib", out Mod goat))
            {
                GOATLIB = goat;

                AddDetour(typeof(GPlayer), "ProcessTransformationTriggers");
            }
            if (ModLoader.TryGetMod("DBZMODPORT", out Mod dbz))
            {
                DBZMOD = dbz;

                var BaseProj = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("BaseBeam"));
                var myPlayer = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer"));
                var baseBeamCharge = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("BaseBeamCharge"));
                var AbstractChargeBall = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("AbstractChargeBall"));
                var transBuff = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("TransBuff"));

                AddHook(BaseProj.AsType(), "ModifyHitNPC", typeof(Hooks), "BaseBeam_ModifyHitNPC_Hook");

                AddHook(myPlayer.AsType(), "ResetEffects", typeof(Hooks), "MyPlayer_ResetEffects_Hook");

                AddHook(myPlayer.AsType(), "PowerWishMulti", typeof(Hooks), "MyPlayer_PowerWishMulti_Hook");

                AddHook(myPlayer.AsType(), "HandlePowerWishMultipliers", typeof(Hooks), "MyPlayer_HandlePowerWishMultipliers_Hook");

                AddHook(baseBeamCharge.AsType(), "GetBeamPowerMultiplier", typeof(Hooks), "BaseBeamCharge_GetBeamPowerMultiplier_Hook");
                AddHook(baseBeamCharge.AsType(), "GetBeamDamage", typeof(Hooks), "BaseBeamCharge_GetBeamDamage_Hook");

                AddHook(AbstractChargeBall.AsType(), "HandleChargingKi", typeof(Hooks), "AbstractChargeBall_HandleChargingKi_Hook");

                AddHook(transBuff.AsType(), "AssembleTransBuffDescription", typeof(BuffHooks), "BuildTooltip_Hook");

                foreach (var acc in AccessoryHooks.upgradePaths)
                {
                    var type = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals(acc.Key));

                    AddHook(type.AsType(), "UpdateAccessory", typeof(AccessoryHooks), "Update_hook");
                }
                foreach (var acc in AccessoryHooks.ChagnedTooltips)
                {
                    var type = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals(acc.Key));

                    AddHook(type.AsType(), "SetStaticDefaults", typeof(AccessoryHooks), "SetStaticDefaults_Hook");
                }

                foreach (var adj in BuffHooks.DBT_Adjustments)
                {
                    var type = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals(adj.Key));

                    AddHook(type.AsType(), "SetStaticDefaults", typeof(BuffHooks), "SetStaticDefaults_Hook");
                    AddHook(type.AsType(), "Update", new Type[] { typeof(Player), typeof(int).MakeByRefType() }, typeof(BuffHooks), "Update_Hook");
                }

                foreach (var armor in ArmorHooks.DBT_Armor)
                {
                    var type = DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals(armor));
                    AddHook(type.AsType(), "SetDefaults", typeof(ArmorHooks), "Armor_SetStaticDefaults");
                }
            }
            
            if(ModLoader.TryGetMod("dbzcalamity",out Mod dbca))
            {
                DBCA = dbca;

                var dbcaplayer = dbca.Code.DefinedTypes.First(x => x.Name.Equals("dbzcalamityPlayer"));

                AddHook(dbcaplayer.AsType(), "GetDodgeCost", typeof(Hooks), "DBCA_GetDodgeCost_Hook");

                foreach (var acc in AccessoryHooks.dbcaUpgradePaths)
                {
                    var type = dbca.Code.DefinedTypes.First(x => x.Name.Equals(acc.Key));

                    AddHook(type.AsType(), "UpdateAccessory", typeof(AccessoryHooks), "Update_hook");
                }
                foreach (var acc in AccessoryHooks.DBCAChagnedToolttips)
                {
                    var type = dbca.Code.DefinedTypes.First(x => x.Name.Equals(acc.Key));

                    AddHook(type.AsType(), "SetStaticDefaults", typeof(AccessoryHooks), "SetStaticDefaults_Hook");
                }
                foreach (var adj in BuffHooks.DBCA_Adjustments)
                {
                    var type = dbca.Code.DefinedTypes.First(x => x.Name.Equals(adj.Key));

                    AddHook(type.AsType(), "SetStaticDefaults", typeof(BuffHooks), "SetStaticDefaults_Hook");
                }
                foreach (var armor in ArmorHooks.DBCA_Armor)
                {
                    var type = dbca.Code.DefinedTypes.First(x => x.Name.Equals(armor));
                    AddHook(type.AsType(), "SetDefaults", typeof(ArmorHooks), "Armor_SetStaticDefaults");
                }
            }

        }
        public override void Unload()
        {
            Instance = null;
            DBZMOD = null;
            DBCA = null;
            GOATLIB = null;

            for (int i = 0; i < Detours.Count; i++)
                if (Detours[i].IsApplied)
                {
                    Detours[i].Undo();
                    Detours[i].Free();
                    Detours[i].Dispose();
                }
            for (int i = 0; i < Hooks.Count; i++)
                if (Hooks[i].IsApplied)
                {
                    Hooks[i].Undo();
                    Hooks[i].Free();
                    Hooks[i].Dispose();
                }
        }
        
        public void AddHook(Type type, string name, Type to, string toName)
        {
            Logger.Info($"type {type.FullName}   name {name}   methodType Method   to {to.FullName}   toName {toName}");

            MethodInfo method;
            method = type.GetMethod(name, flagsAll);
            
            var hook = new Hook(method, to.GetMethod(toName, flagsAll));

            hook.Apply();

            Hooks.Add(hook);
        }
        public void AddHook(Type type, string name, Type[] args, Type to, string toName)
        {
            Logger.Info($"type {type.FullName}   name {name}   methodType Method   to {to.FullName}   toName {toName}");

            MethodInfo method;
            method = type.GetMethod(name, flagsAll, args);

            var hook = new Hook(method, to.GetMethod(toName, flagsAll));

            hook.Apply();

            Hooks.Add(hook);
        }
        public void AddDetour(Type type, string name, bool methodType, Type to, string toName)
        {
            Logger.Info($"type {type.FullName}   name {name}   methodType {(methodType ? "Method" : "Property")}   to {to.FullName}   toName {toName}");

            MethodInfo method;
            if (methodType)
            {
                method = type.GetMethod(name, flagsAll);
            }
            else
            {
                method = type.GetProperty(name, flagsAll).GetMethod;
            }

            var detour = new Detour(method, to.GetMethod(toName, flagsAll));

            detour.Apply();

            Detours.Add(detour);
        }
        public void AddDetour(Type type, string name, Type[] args, Type to, string toName)
        {
            Logger.Info($"type {type.FullName}   name {name}   args {{{string.Join(",", args.Select(a => a.FullName))}}}   to {to.FullName}   toName {toName}");

            Detours.Add(new Detour(type.GetMethod(name, args), to.GetMethod(toName, flagsAll)));
        }
        public void AddDetour(Type type, string name) =>
            Detours.Add(new Detour(type.GetMethod(name, flagsAll), GetType().GetMethod("Nothing", flagsAll)));
        public void Nothing() { }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            BNetworkHandler.HandlePacket(reader, whoAmI);
        }
    }
}