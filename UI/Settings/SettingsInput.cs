using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsInput : Settings
    {
        internal string placeholder;
        public string value;

        public SettingsInput(string id, string placeholder)
        {
            base.id = id;
            this.placeholder = placeholder;
        }

        public void HandleNewValue(string str)
        {
            this.value = str;

            base.SettingsUpdated();
        }
    }
}
