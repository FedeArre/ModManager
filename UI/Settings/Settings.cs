using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModManager
{
    public class Settings
    {
        public string id;
        public GameObject parent; // Holds the template
        public ModSettings modSettings;

        internal void SettingsUpdated()
        {
            modSettings.settingsUpdate();
        }
    }
}
