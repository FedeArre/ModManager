using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace ModManager
{
    public class ModSettings
    {
        internal string modId;
        internal List<Settings> settingList;

        public ModSettings(string modId)
        {
            this.modId = modId;
            settingList = new List<Settings>();
        }
        public SettingsLabel AddLabel(string text)
        {
            SettingsLabel settingLabel = new SettingsLabel(text);
            settingList.Add(settingLabel);
            return settingLabel;
        }

        public SettingsSlider AddSlider(float minValue, float maxValue)
        {
            SettingsSlider ss = new SettingsSlider(minValue, maxValue);
            settingList.Add(ss);
            return ss;
        }

        public SettingsSlider AddSlider(float minValue, float maxValue, UnityAction<float> funtionToCall)
        {
            SettingsSlider ss = new SettingsSlider(minValue, maxValue, funtionToCall);
            settingList.Add(ss);
            return ss;
        }
    }
}
