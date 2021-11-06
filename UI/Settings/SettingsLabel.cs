using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModManager
{
    public class SettingsLabel : Settings
    {
        public string text;

        public SettingsLabel(string id, string text)
        {
            base.id = id;
            this.text = text;
        }
    }
}
