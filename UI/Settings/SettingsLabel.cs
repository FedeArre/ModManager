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

        public SettingsLabel(string text)
        {
            this.text = text;
        }
    }
}
