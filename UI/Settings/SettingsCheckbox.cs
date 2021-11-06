using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsCheckbox : Settings
    {
        public bool ticked;
        public string text;

        public SettingsCheckbox(string text, bool ticked)
        {
            this.text = text;
            this.ticked = ticked;
        }

        internal void HandleChange(bool value)
        {
            ticked = value;
            base.SettingsUpdated();
        }
    }
}
