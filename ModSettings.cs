using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class ModSettings
    {
        private string modId;
        private List<Settings> settingList;

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

    }
}
