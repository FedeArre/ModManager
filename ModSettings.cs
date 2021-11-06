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
        
        public delegate void SettingsUpdateDelegate();
        public event SettingsUpdateDelegate SettingsUpdated;

        public ModSettings(string modId)
        {
            this.modId = modId;
            settingList = new List<Settings>();
        }

        internal void settingsUpdate()
        {
            OnModSettingsUpdate();
        }

        protected virtual void OnModSettingsUpdate()
        {
            if(SettingsUpdated != null)
            {
                SettingsUpdated?.Invoke();
            }
        }

        public void LoadSettings()
        {

        }

        public SettingsLabel AddLabel(string id, string text)
        {
            SettingsLabel sl = new SettingsLabel(id, text);
            sl.modSettings = this;
            settingList.Add(sl);

            return sl;
        }

        public SettingsSlider AddSlider(string id, float minValue, float maxValue, int numberCount)
        {
            SettingsSlider ss = new SettingsSlider(id, minValue, maxValue, numberCount);
            ss.modSettings = this;
            settingList.Add(ss);

            return ss;
        }
        public SettingsSlider AddSlider(string id, float minValue, float maxValue, int numberCount, double defaultValue)
        {
            SettingsSlider ss = new SettingsSlider(id, minValue, maxValue, numberCount, defaultValue);
            ss.modSettings = this;
            settingList.Add(ss);

            return ss;
        }

        public SettingsSlider AddSlider(string id, float minValue, float maxValue, int numberCount, double defaultValue, UnityAction<float> funtionToCall)
        {
            SettingsSlider ss = new SettingsSlider(id, minValue, maxValue, numberCount, defaultValue, funtionToCall);
            ss.modSettings = this;
            settingList.Add(ss);

            return ss;
        }

        public SettingsInput AddInput(string id, string placeholder = "")
        {
            SettingsInput si = new SettingsInput(id, placeholder);
            si.modSettings = this;
            settingList.Add(si);

            return si;
        }

        public SettingsButton AddButton(string id, string text)
        {
            SettingsButton sb = new SettingsButton(id, text);
            sb.modSettings = this;
            settingList.Add(sb);

            return sb;
        }

        public SettingsCheckbox AddToggle(string id, string text, bool ticked = false)
        {
            SettingsCheckbox sc = new SettingsCheckbox(id, text, ticked);
            sc.modSettings = this;
            settingList.Add(sc);

            return sc;
        }
    }
}
