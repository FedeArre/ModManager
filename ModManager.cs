using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModManager
{
    public class ModManager : Mod
    {
        public override string ID => "ModManager";
        public override string Name => "ModManager";
        public override string Author => "Federico Arredondo";
        public override string Version => "1.0.0";

        internal static List<ModSettings> RegisteredMods = new List<ModSettings>();

        public static ModSettings RegisterMod(string modId)
        {
            ModSettings ms = new ModSettings(modId);
            RegisteredMods.Add(ms);
            return ms;
        }
    }
}
