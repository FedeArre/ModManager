using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModManager
{
    public class SettingsSlider : Settings
    {
        internal float minValue;
        internal float maxValue;
        internal int numberCount;
        internal string title;

        public double value;

        public SettingsSlider(string id, float minValue, float maxValue, int numberCount, string title)
        {
            base.id = id;

            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
            this.title = title;
        }

        internal void HandlerSlider(float value)
        {
            double newValue = Math.Round((double)value, numberCount);
            base.parent.transform.GetChild(1).GetComponent<Text>().text = $"{newValue}";
            this.value = newValue;

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
