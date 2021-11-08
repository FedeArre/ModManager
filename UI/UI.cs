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

        internal GameObject youtube;
        internal GameObject discord;
        internal GameObject version;

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

            youtube = canvas.transform.GetChild(4).gameObject;
            discord = canvas.transform.GetChild(5).gameObject;
            version = canvas.transform.GetChild(6).gameObject;

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
