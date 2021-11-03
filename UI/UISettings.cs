using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModManager
{
    public class UISettings
    {
        private static UISettings instance;

        private UIControl ui;

        internal GameObject templateMod;
        // Templates of the settings in the prefab.
        internal GameObject settLabelTemplate;
        internal GameObject settSliderTemplate;

        public string displayingModId;

        private UISettings()
        {
            ui = UIControl.GetInstance();

            // Using getchild would be faster if im not wrong but this is safer (at least while developing the mod).
            templateMod = GameObject.Find("ModInfoTemplate");
            settLabelTemplate = GameObject.Find("SettingLabelTemplate");
            settSliderTemplate = GameObject.Find("SettingSlideremplate");
        }

        public static UISettings GetInstance()
        {
            if (instance == null)
                instance = new UISettings();
            return instance;
        }

        public void LoadMenuOfMod(Mod mod)
        {
            displayingModId = mod.ID;

            GameObject modInfo = GameObject.Instantiate(templateMod);
            // Toggle mod enabled or not
            modInfo.transform.GetChild(0).GetComponent<Toggle>().isOn = mod.enabled;
            modInfo.transform.GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener(ui.HandleEnableDisableMod);
            modInfo.transform.GetChild(0).name = displayingModId;

            // Version and showing up "Mod settings" title
            modInfo.transform.GetChild(1).GetComponent<Text>().text = $"Version: {mod.Version}";
            modInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            foreach (ModSettings ms in ModManager.RegisteredMods)
            {
                if(ms.modId == displayingModId)
                {
                    if(ms.settingList.Count > 0)
                    {
                        modInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mod settings";
                    }
                }
            }

            // Hooking it into the list.
            modInfo.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
        }
    }
}
