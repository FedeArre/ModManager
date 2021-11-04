using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsButton : Settings
    {
        internal string text;

        public SettingsButton(string text)
        {
            this.text = text;
        }

        internal void HandleClick()
        {
            
        }
    }
}
