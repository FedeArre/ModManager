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
            ms.AddInput("input1", "gib text pls:");
            ms.LoadSettings();
        }

        public override void OnMenuLoad()
        {
            UI.GetInstance().version.GetComponent<TextMeshProUGUI>().text = $"{Application.version}";
            GameObject.Destroy(GameObject.Find("VersionNumber"));

            GameObject discordButton = GameObject.Find("discoirdbutt");
            GameObject youtubeButton = GameObject.Find("youtubebut");

            discordButton.transform.SetParent(UI.GetInstance().discord.transform);
            youtubeButton.transform.SetParent(UI.GetInstance().youtube.transform);

            discordButton.transform.localPosition = Vector3.zero;
            youtubeButton.transform.localPosition = Vector3.zero;
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
