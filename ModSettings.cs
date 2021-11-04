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

        public SettingsSlider AddSlider(float minValue, float maxValue, int numberCount)
        {
            SettingsSlider ss = new SettingsSlider(minValue, maxValue, numberCount);
            settingList.Add(ss);
            return ss;
        }
        public SettingsSlider AddSlider(float minValue, float maxValue, int numberCount, double defaultValue)
        {
            SettingsSlider ss = new SettingsSlider(minValue, maxValue, numberCount, defaultValue);
            settingList.Add(ss);
            return ss;
        }

        public SettingsSlider AddSlider(float minValue, float maxValue, int numberCount, double defaultValue, UnityAction<float> funtionToCall)
        {
            SettingsSlider ss = new SettingsSlider(minValue, maxValue, numberCount, defaultValue, funtionToCall);
            settingList.Add(ss);
            return ss;
        }

        public SettingsInput AddInput(string placeholder = "")
        {
            SettingsInput si = new SettingsInput(placeholder);
            settingList.Add(si);
            return si;
        }

        public SettingsInput AddButton(string text)
        {
            Settings sb = new SettingsButton(text);
            settingList.Add(sb);
            return sb;
        }
    }
}
