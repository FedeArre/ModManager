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

            ModSettings ms = RegisterMod(ID);
            ms.AddLabel("Hello world");
            ms.AddLabel("This was done by code only!");
            ms.AddSlider(4f, 6f, 2);
            ms.AddSlider(1f, 10f, 0);
            ms.AddInput();
            ms.AddInput("bad gui lul");
            ms.AddButton("hi");
            ms.AddButton("hi");
            ms.AddToggle("hello!!");
        }

        public static ModSettings RegisterMod(string modId)
        {
            ModSettings ms = new ModSettings(modId);
            RegisteredMods.Add(ms);
            return ms;
        }
    }
}
