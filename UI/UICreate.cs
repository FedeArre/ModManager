using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ModManager
{
    internal class UICreate
    {
        private static UICreate instance;

        internal GameObject canvas;

        private AssetBundle bundle;

        private UICreate()
        {
            bundle = AssetBundle.LoadFromMemory(Properties.Resources.ui);

            canvas = bundle.LoadAsset<GameObject>("Canvas");
            canvas = GameObject.Instantiate(canvas);
            GameObject.DontDestroyOnLoad(canvas);

            UIControl.GetInstance().canvas = canvas;
        }

        public static UICreate GetInstance()
        {
            if (instance == null)
                instance = new UICreate();
            return instance;
        }
    }
}
