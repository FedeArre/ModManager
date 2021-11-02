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
        internal GameObject eventSystem;
        internal GameObject buttonModShow;
        internal GameObject scrollCanva;
        internal GameObject modTemplate;

        private AssetBundle bundle;

        private bool scrollCanvaShown;

        private UICreate()
        {
            bundle = AssetBundle.LoadFromMemory(Properties.Resources.ui);

            canvas = bundle.LoadAsset<GameObject>("Canvas");
            canvas = GameObject.Instantiate(canvas);
            GameObject.DontDestroyOnLoad(canvas);

            eventSystem = bundle.LoadAsset<GameObject>("EventSystem");
            eventSystem = GameObject.Instantiate(eventSystem);
            GameObject.DontDestroyOnLoad(eventSystem);
            
            scrollCanva = GameObject.Find("ModList");
            buttonModShow = GameObject.Find("ModListButton");
            modTemplate = GameObject.Find("ModTemplate");

            scrollCanva.SetActive(scrollCanvaShown);

            buttonModShow.GetComponent<Button>().onClick.AddListener(HandleModButton);
            buttonModShow.SetActive(true);
        }

        public static UICreate GetInstance()
        {
            if (instance == null)
                instance = new UICreate();
            return instance;
        }

        public void HandleModButton()
        {
            Debug.LogError("fa");
            scrollCanvaShown = !scrollCanvaShown;
            scrollCanva.SetActive(scrollCanvaShown);
        }
    }
}
