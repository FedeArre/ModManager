using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ModManager
{
    public class SettingsKeybind : Settings
    {
        public KeyCode multiplierSelectedKey;
        internal GameObject searchingKey;

        public SettingsKeybind(string id, KeyCode multiplierKey)
        {
            base.id = id;
            this.multiplierSelectedKey = multiplierKey;
        }

        internal void OnValueChanged()
        {
            // Saving - TESTING PENDING
            if (modSettings.values.TryGetValue(base.id, out object val))
            {
                modSettings.values[base.id] = (int) this.multiplierSelectedKey;
            }
            else
            {
                modSettings.values.Add(base.id, (int) this.multiplierSelectedKey);
            }

            File.Create(Utils.MODS_SETTINGS_FOLDER_PATH + $"{base.modSettings.modInstance.ID}.json").Dispose();
            using (TextWriter tw = new StreamWriter(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{base.modSettings.modInstance.ID}.json"))
            {
                tw.Write(JsonConvert.SerializeObject(modSettings.values));
            }
        }

        internal void HandleButtonPress()
        {
            if (searchingKey)
                return;

            base.parent.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Press any key";

            searchingKey = new GameObject("KeybindFindHelper");
            searchingKey.AddComponent<KeybindHelper>().parentSetting = this;
        }

        internal void FoundNewKey(int kc)
        {
            if (!searchingKey)
                return;

            GameObject.Destroy(searchingKey);

            KeyCode keyCode = (KeyCode)kc;
            multiplierSelectedKey = keyCode == KeyCode.Escape ? KeyCode.None : keyCode;
            OnValueChanged();

            base.parent.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = multiplierSelectedKey.ToString();
        }
    }
}
