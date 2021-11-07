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
        public bool isTitle;

        public SettingsLabel(string id, string text, bool isTitle)
        {
            base.id = id;
            this.text = text;
            this.isTitle = isTitle;
        }
    }
}
