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

        public ModManager()
        {
            UICreate.GetInstance();

            ModSettings ms = RegisterMod(this);
            ms.AddSlider("slider1", 2, 5, 0);
            ms.LoadSettings();
        }

        public static ModSettings RegisterMod(Mod mod)
        {
            ModSettings ms = new ModSettings(mod);
            RegisteredMods.Add(ms);
            return ms;
        }
    }
}
