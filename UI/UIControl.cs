using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ModManager
{
    internal class UIControl
    {
        private static UIControl instance;

        private bool scrollCanvaShown;
        private bool loadedMods;

        internal GameObject buttonModShow;
        internal GameObject scrollCanva;
        internal GameObject modTemplate;
        internal GameObject closeMenuButton;
        internal GameObject canvas;

        private UIControl()
        {
            scrollCanva = GameObject.Find("ModList");
            buttonModShow = GameObject.Find("ModListButton");
            modTemplate = GameObject.Find("ModTemplate");
            closeMenuButton = GameObject.Find("CloseModListButton");

            scrollCanva.SetActive(false);

            buttonModShow.GetComponent<Button>().onClick.AddListener(HandleShowHideMenuButton);
            closeMenuButton.GetComponent<Button>().onClick.AddListener(HandleShowHideMenuButton);
        }

        public static UIControl GetInstance()
        {
            if (instance == null)
                instance = new UIControl();
            return instance;
        }

        public void HandleShowHideMenuButton()
        {
            scrollCanvaShown = !scrollCanvaShown;
            scrollCanva.SetActive(scrollCanvaShown); 
            if (!loadedMods)
            {
                LoadList();
            }
        }
        
        public void HandleDetailsSettingsButton()
        {

        }

        private void LoadList()
        {
            foreach (Mod mod in ModLoader.mods)
            {
                GameObject tempGameObject = GameObject.Instantiate(modTemplate);
                tempGameObject.transform.GetChild(0).GetComponent<Text>().text = mod.Name;
                if (mod.Icon != null)
                {
                    // This probably doesn't work.
                    Texture2D txt = new Texture2D(1, 1);
                    txt.LoadImage(mod.Icon);
                    tempGameObject.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(txt, new Rect(0, 0, txt.width, txt.height), new Vector2(0.5f, 0.5f));
                }
                // Details & Settings button
                tempGameObject.transform.GetChild(2).name = mod.ID;
                tempGameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(HandleDetailsSettingsButton);

                tempGameObject.transform.GetChild(3).GetComponent<Text>().text = "Author: " + mod.Author;
                tempGameObject.transform.SetParent(scrollCanva.transform.GetChild(0).GetChild(0));
            }
            loadedMods = true;
        }
    }
}
