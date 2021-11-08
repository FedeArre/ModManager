using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsInput : Settings
    {
        internal string text;
        public string value;
        
        public SettingsInput(string id, string text)
        {
            base.id = id;
            this.text = text;
        }

        public void HandleNewValue(string str)
        {
            this.value = str;

            // Saving.
            if (modSettings.values.TryGetValue(base.id, out object val))
            {
                modSettings.values[base.id] = this.value;
            }
            else
            {
                modSettings.values.Add(base.id, this.value);
            }

            File.Create(Utils.MODS_SETTINGS_FOLDER_PATH + $"{base.modSettings.modInstance.ID}.json").Dispose();
            using (TextWriter tw = new StreamWriter(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{base.modSettings.modInstance.ID}.json"))
            {
                tw.Write(JsonConvert.SerializeObject(modSettings.values));
            }

            base.SettingsUpdated();
        }
    }
}
