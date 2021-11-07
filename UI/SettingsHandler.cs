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
    internal class SettingsHandler
    {
        private static SettingsHandler instance;

        private UIHandler ui;

        internal GameObject templateMod;
        // Templates of the settings in the prefab.
        internal GameObject settLabelTemplate;
        internal GameObject settSliderTemplate;
        internal GameObject settInputTemplate;
        internal GameObject settCheckboxTemplate;
        internal GameObject settButtonTemplate;
        internal GameObject settTitleTemplate;
        internal GameObject settKeybindTemplate;

        internal string displayingModId;

        private SettingsHandler()
        {
            ui = UIHandler.GetInstance();

            // Using getchild would be faster if im not wrong but this is safer (at least while developing the mod).
            templateMod = GameObject.Find("ModInfoTemplate");
            settLabelTemplate = GameObject.Find("SettingLabelTemplate");
            settSliderTemplate = GameObject.Find("SettingSliderTemplate");
            settInputTemplate = GameObject.Find("SettingInputTemplate");
            settCheckboxTemplate = GameObject.Find("SettingCheckboxTemplate");
            settButtonTemplate = GameObject.Find("SettingButtonTemplate");
            settTitleTemplate = GameObject.Find("SettingTitleTemplate");
            settKeybindTemplate = GameObject.Find("SettingKeybindTemplate");
        }

        public static SettingsHandler GetInstance()
        {
            if (instance == null)
                instance = new SettingsHandler();
            return instance;
        }

        /// <summary>
        /// Loads the settings menu (including mod info) of the provided Mod. 
        /// </summary>
        /// <param name="mod">The Mod instance, can't be null</param>
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

            ModSettings modSettings = null;
            foreach (ModSettings ms in ModManager.RegisteredMods)
            {
                if(ms.modInstance.ID == displayingModId)
                {
                    if(ms.settingList.Count > 0)
                    {
                        modSettings = ms;
                        modInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mod settings";
                    }
                }
            }
            // Hooking it into the list.
            modInfo.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));

            // Now we start loading our settings.
            if (modSettings == null)
                return;

            foreach(Settings setting in modSettings.settingList)
            {
                switch (setting)
                {
                    case SettingsLabel sl:
                        GameObject labelTemplate = GameObject.Instantiate(sl.isTitle ? settTitleTemplate : settLabelTemplate);
                        if (!sl.isTitle)
                            labelTemplate.transform.GetChild(0).GetComponent<Text>().text = sl.text;
                        else
                            labelTemplate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = sl.text;

                        setting.parent = labelTemplate;

                        labelTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;
                
                    case SettingsSlider ss:
                        GameObject sliderTemplate = GameObject.Instantiate(settSliderTemplate);
                        Slider sliderComponent = sliderTemplate.transform.GetChild(0).GetComponent<Slider>();
                        sliderComponent.minValue = ss.minValue;
                        sliderComponent.maxValue = ss.maxValue;
                        sliderComponent.value = (float) ss.value;
                        sliderTemplate.transform.GetChild(1).GetComponent<Text>().text = $"{ss.value}";

                        if(ss.numberCount == 0)
                        {
                            sliderComponent.wholeNumbers = true;
                        }

                        sliderComponent.onValueChanged.AddListener(ss.HandlerSlider);

                        setting.parent = sliderTemplate;

                        sliderTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;
                    case SettingsInput si:
                        GameObject inputTemplate = GameObject.Instantiate(settInputTemplate);
                        TMP_InputField input = inputTemplate.transform.GetChild(0).GetComponent<TMP_InputField>();

                        //inputTemplate.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = si.placeholder; TODO: I didn't found which component handles the text. Is a TMP but i didn't found which

                        input.onValueChanged.AddListener(si.HandleNewValue);

                        setting.parent = inputTemplate;
                        inputTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;

                    case SettingsButton sb:
                        GameObject buttonTemplate = GameObject.Instantiate(settButtonTemplate);
                        Button butt = buttonTemplate.transform.GetChild(0).GetComponent<Button>();

                        buttonTemplate.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = sb.text;
                        butt.onClick.AddListener(sb.HandleClick);

                        setting.parent = buttonTemplate;

                        buttonTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;

                    case SettingsCheckbox sc:
                        GameObject checkboxTemplate = GameObject.Instantiate(settCheckboxTemplate);
                        Toggle toggle = checkboxTemplate.transform.GetChild(0).GetComponent<Toggle>();

                        toggle.isOn = sc.ticked;
                        toggle.onValueChanged.AddListener(sc.HandleChange);

                        setting.parent = checkboxTemplate;

                        checkboxTemplate.transform.GetChild(1).GetComponent<Text>().text = sc.text;

                        checkboxTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;

                    case SettingsKeybind sk:
                        GameObject keybindTemplate = GameObject.Instantiate(settKeybindTemplate);
                        Button button = keybindTemplate.transform.GetChild(0).GetComponent<Button>();
                        TextMeshProUGUI text = keybindTemplate.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

                        button.onClick.AddListener(sk.HandleButtonPress);
                        text.text = sk.selectedKey.ToString();

                        setting.parent = keybindTemplate;

                        keybindTemplate.transform.SetParent(ui.scrollCanva.transform.GetChild(0).GetChild(0));
                        break;
                }
            }
        }
    }
}
