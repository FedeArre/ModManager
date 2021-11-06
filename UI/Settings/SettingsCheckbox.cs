using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsCheckbox : Settings
    {
        public bool ticked;
        public string text;

        public SettingsCheckbox(string id, string text, bool ticked)
        {
            base.id = id;
            this.text = text;
            this.ticked = ticked;
        }

        internal void HandleChange(bool value)
        {
            ticked = value;

            // Saving.
            if (modSettings.values.TryGetValue(base.id, out object val))
            {
                modSettings.values[base.id] = this.ticked;
            }
            else
            {
                modSettings.values.Add(base.id, this.ticked);
            }

            File.Create(Utils.MODS_FOLDER_PATH + $"/{base.id}.json").Dispose();
            using (TextWriter tw = new StreamWriter(Utils.MODS_SETTINGS_FOLDER_PATH + $"/{base.modSettings.modInstance.ID}.json"))
            {
                tw.Write(JsonConvert.SerializeObject(modSettings.values));
            }


            base.SettingsUpdated();
        }
    }
}
