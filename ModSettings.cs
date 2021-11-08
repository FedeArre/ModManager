using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace ModManager
{
    public class ModSettings
    {
        internal Mod modInstance;
        internal List<Settings> settingList;
        internal Dictionary<string, object> values;

        public delegate void SettingsUpdateDelegate();
        public event SettingsUpdateDelegate SettingsUpdated;

        public ModSettings(Mod mod)
        {
            values = new Dictionary<string, object>();
            this.modInstance = mod;
            settingList = new List<Settings>();
        }

        /// <summary>
        /// Internally called function from a Settings object to indicate that a setting was updated.
        /// </summary>
        internal void settingsUpdate()
        {
            OnModSettingsUpdate();
        }

        /// <summary>
        /// Invokes the SettingsUpdated event.
        /// </summary>
        protected virtual void OnModSettingsUpdate()
        {
            if(SettingsUpdated != null)
            {
                SettingsUpdated?.Invoke();
            }
        }

        /// <summary>
        /// Loads all the mod's settings. Note that you have to use it after registering your settings!
        /// </summary>
        public void LoadSettings()
        {
            // TODO add trycatchs to this function
            // Check if the mod settings directory exists, if not create it.
            if (!Directory.Exists(Utils.MODS_SETTINGS_FOLDER_PATH))
            {
                Directory.CreateDirectory(Utils.MODS_SETTINGS_FOLDER_PATH);
            }

            if(!File.Exists(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{modInstance.ID}.json"))
            {
                File.Create(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{modInstance.ID}.json").Dispose();
            }

            using (StreamReader r = new StreamReader(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{modInstance.ID}.json"))
            {
                string json = r.ReadToEnd();
                if(json.Length > 1)
                    values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }

            foreach (KeyValuePair<string, object> entry in values)
            {
                Settings s = Utils.GetSettingByIdInList(settingList, entry.Key);
                if (s == null)
                    continue;

                switch (s)
                {
                    case SettingsCheckbox sc:
                        sc.ticked = (bool) entry.Value;
                        break;

                    case SettingsSlider ss:
                        ss.value = (double) entry.Value;
                        break;

                    case SettingsInput si:
                        si.value = (string) entry.Value;
                        break;
                    case SettingsKeybind sk:
                        sk.selectedKey = (KeyCode)Int32.Parse(entry.Value.ToString()); // Cant use int -> KeyCode since entry.Value is object.
                        break;
                }
            }
        }

        /// <summary>
        /// Creates a "Label" setting.
        /// </summary>
        /// <param name="id">The id of the setting, has to be unique</param>
        /// <param name="text">The text of the label</param>
        /// <param name="isTitle">If the label is a title or not</param>
        /// <returns>A SettingLabel instance</returns>
        public SettingsLabel AddLabel(string id, string text, bool isTitle)
        {
            SettingsLabel sl = new SettingsLabel(id, text, isTitle);
            sl.modSettings = this;
            settingList.Add(sl);

            return sl;
        }

        /// <summary>
        /// Adds a "Slider" setting.
        /// </summary>
        /// <param name="id">The id of the setting, has to be unique</param>
        /// <param name="minValue">The minimum value that the slider will go</param>
        /// <param name="maxValue">The maximum value that the slider will go</param>
        /// <param name="numberCount">Number of decimals to count. Use 0 for integers</param>
        /// <param name="title">A text that is shown at the top left of the slidel (optional)</param>
        /// <returns>A SettingSlider instance</returns>
        public SettingsSlider AddSlider(string id, float minValue, float maxValue, int numberCount, string title = "")
        {
            SettingsSlider ss = new SettingsSlider(id, minValue, maxValue, numberCount, title);
            ss.modSettings = this;
            settingList.Add(ss);

            return ss;
        }

        /// <summary>
        /// Adds a "Input" setting.
        /// </summary>
        /// <param name="id">The id of the setting, has to be unique</param>
        /// <param name="leftText">The text that is located at the left of the input</param>
        /// <returns>A SettingsInput instance</returns>
        public SettingsInput AddInput(string id, string leftText)
        {
            SettingsInput si = new SettingsInput(id, leftText);
            si.modSettings = this;
            settingList.Add(si);

            return si;
        }

        /// <summary>
        /// Adds a "Button" setting
        /// TODO: Add a way to handling the buttons clicks using Actions
        /// </summary>
        /// <param name="id">The id of the setting, has to be unique</param>
        /// <param name="text">The text inside the button</param>
        /// <returns>A SettingsButton instance</returns>
        public SettingsButton AddButton(string id, string text)
        {
            SettingsButton sb = new SettingsButton(id, text);
            sb.modSettings = this;
            settingList.Add(sb);

            return sb;
        }

        /// <summary>
        /// Adds a "Toggle" (also known as Checkbox) setting
        /// </summary>
        /// <param name="id">The id of the setting, has to be unique</param>
        /// <param name="text">The text that will be located next to the toggle</param>
        /// <returns>A SettingsCheckbox instance</returns>
        public SettingsCheckbox AddToggle(string id, string text)
        {
            SettingsCheckbox sc = new SettingsCheckbox(id, text, false);
            sc.modSettings = this;
            settingList.Add(sc);

            return sc;
        }

        public SettingsKeybind AddKeybind(string id, KeyCode keyCode)
        {
            SettingsKeybind sk = new SettingsKeybind(id, keyCode);
            sk.modSettings = this;

            settingList.Add(sk);
            return sk;
        }
    }
}
