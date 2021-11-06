using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager
{
    public class SettingsButton : Settings
    {
        // TODO i still didn't decided how to implement the button handler. Using delegates? Passing the function as reference?
        internal string text;

        public SettingsButton(string text)
        {
            this.text = text;
        }

        internal void HandleClick()
        {

            base.SettingsUpdated();
        }
    }
}
