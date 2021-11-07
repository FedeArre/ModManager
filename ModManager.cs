using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            UI.GetInstance().CreateUI();

            ModSettings ms = RegisterMod(this);
            ms.AddSlider("slider1", 2, 5, 0);
            ms.AddLabel("label1", "Key for noclip", true);
            ms.LoadSettings();
        }

        public override void OnMenuLoad()
        {
            GameObject.Destroy(GameObject.Find("VersionNumber")); // Fixes broken "Mods" button due to overlapping.
        }

        /// <summary>
        /// This function registers a mod into the mod manager.
        /// </summary>
        /// <param name="mod">The mod instance of the mod to register</param>
        /// <returns>A unique ModSettings instance for the mod</returns>
        public static ModSettings RegisterMod(Mod mod)
        {
            ModSettings ms = new ModSettings(mod);
            RegisteredMods.Add(ms);
            return ms;
        }
    }
}
