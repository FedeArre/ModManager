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
        internal GameObject closeMenuButton;

        private AssetBundle bundle;

        private bool scrollCanvaShown;
        private bool loadedMods;

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
            closeMenuButton = GameObject.Find("CloseModListButton");

            scrollCanva.SetActive(scrollCanvaShown);

            buttonModShow.GetComponent<Button>().onClick.AddListener(HandleModButton);
            buttonModShow.SetActive(true);

            closeMenuButton.GetComponent<Button>().onClick.AddListener(HandleModButton);
            closeMenuButton.SetActive(true);
        }

        public static UICreate GetInstance()
        {
            if (instance == null)
                instance = new UICreate();
            return instance;
        }

        public void HandleModButton()
        {
            scrollCanvaShown = !scrollCanvaShown;
            scrollCanva.SetActive(scrollCanvaShown);
            if(!loadedMods)
            {
                LoadList();
            }
        }

        private void LoadList()
        {
            foreach(Mod mod in ModLoader.mods)
            {
                GameObject tempGameObject = GameObject.Instantiate(modTemplate);
                tempGameObject.transform.GetChild(0).GetComponent<Text>().text = mod.Name;
                // TO - DO icon.
                tempGameObject.transform.GetChild(3).GetComponent<Text>().text = "Author: " + mod.Author;
                tempGameObject.transform.SetParent(scrollCanva.transform.GetChild(0).GetChild(0));
            }
            loadedMods = true;
        }
    }
}
