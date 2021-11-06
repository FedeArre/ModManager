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

        public delegate void ButtonClickDelegate();
        public event ButtonClickDelegate OnButtonClick;

        public SettingsButton(string id, string text)
        {
            base.id = id;
            this.text = text;
        }

        internal void HandleClick()
        {
            if(OnButtonClick != null)
                OnButtonClick.Invoke();

            base.SettingsUpdated();
        }
    }
}
