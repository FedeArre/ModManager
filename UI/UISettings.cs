using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModManager
{
    public class UISettings
    {
        private static UISettings instance;

        private UIControl ui;

        internal GameObject templateMod;
        // Templates of the settings in the prefab.
        internal GameObject settLabelTemplate;
        internal GameObject settSliderTemplate;

        private UISettings()
        {
            ui = UIControl.GetInstance();

            // Using getchild would be faster if im not wrong but this is safer (at least while developing the mod).
            templateMod = GameObject.Find("ModInfoTemplate");
            settLabelTemplate = GameObject.Find("SettingLabelTemplate");
            settSliderTemplate = GameObject.Find("SettingSlideremplate");
        }

        public static UISettings GetInstance()
        {
            if (instance == null)
                instance = new UISettings();
            return instance;
        }

        public void LoadMenuOfMod(Mod mod)
        {
            template = 
        }
    }
}
