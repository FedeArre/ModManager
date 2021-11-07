using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ModManager
{
    internal class UI
    {
        private static UI instance;
        private AssetBundle bundle;

        internal GameObject canvas;

        private UI()
        {
            bundle = AssetBundle.LoadFromMemory(Properties.Resources.ui);
        }

        /// <summary>
        /// This function loads the canvas from the AssetBundle and passes a reference of it to the UI handler
        /// </summary>
        public void CreateUI()
        {
            canvas = bundle.LoadAsset<GameObject>("Canvas");
            canvas = GameObject.Instantiate(canvas);

            GameObject.DontDestroyOnLoad(canvas);

            UIHandler.GetInstance().canvas = canvas;
        }

        public static UI GetInstance()
        {
            if (instance == null)
                instance = new UI();
            return instance;
        }
    }
}
