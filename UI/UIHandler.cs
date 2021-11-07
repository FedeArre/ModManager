using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModManager
{
    internal class UIHandler
    {
        private static UIHandler instance;

        private bool scrollCanvaShown;
        private bool loadedMods;

        internal GameObject buttonModShow;
        internal GameObject scrollCanva;
        internal GameObject modTemplate;
        internal GameObject closeMenuButton;
        internal GameObject canvas;

        private UIHandler()
        {
            scrollCanva = GameObject.Find("ModList");
            buttonModShow = GameObject.Find("ModListButton");
            modTemplate = GameObject.Find("ModTemplate");
            closeMenuButton = GameObject.Find("CloseModListButton");
            
            scrollCanva.SetActive(false);

            buttonModShow.GetComponent<Button>().onClick.AddListener(HandleShowHideMenuButton);
            closeMenuButton.GetComponent<Button>().onClick.AddListener(HandleShowHideMenuButton);
        }

        /// <summary>
        /// This function handles the clicking on "Mods" button.
        /// </summary>
        public void HandleShowHideMenuButton()
        {
            ClearList();
            scrollCanvaShown = !scrollCanvaShown;
            scrollCanva.SetActive(scrollCanvaShown); 

            if (!loadedMods)
            {
                LoadList();
            }
        }

        /// <summary>
        /// This function handles the clicking on "Details and Settings" button.
        /// </summary>
        public void HandleDetailsSettingsButton()
        {
            string actualModId = EventSystem.current.currentSelectedGameObject.name;
            Mod mod = Utils.GetModById(actualModId);
            if (mod == null)
                return;

            scrollCanva.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = mod.Name; // Set title as mod name.

            ClearList();
            SettingsHandler.GetInstance().LoadMenuOfMod(mod);
        }

        /// <summary>
        /// This function loads all the loaded mods into the mod list
        /// TODO: Load the mod's icon
        /// </summary>
        public void LoadList()
        {
            scrollCanva.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Mod manager";
            foreach (Mod mod in ModLoader.mods)
            {
                GameObject tempGameObject = GameObject.Instantiate(modTemplate);
                tempGameObject.transform.GetChild(0).GetComponent<Text>().text = mod.Name;
                
                // Details & Settings button
                tempGameObject.transform.GetChild(2).name = mod.ID;
                tempGameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(HandleDetailsSettingsButton);

                tempGameObject.transform.GetChild(3).GetComponent<Text>().text = "Author: " + mod.Author;
                tempGameObject.transform.SetParent(scrollCanva.transform.GetChild(0).GetChild(0));
            }
            loadedMods = true;
        }

        /// <summary>
        /// This function removes all items of the Content that is inside the viewport in the mod list.
        /// </summary>
        public void ClearList()
        {
            Transform contentList = scrollCanva.transform.GetChild(0).GetChild(0);
            for(int i = 0; i < contentList.childCount; i++)
            {
                GameObject.Destroy(contentList.GetChild(i).gameObject);
            }
            loadedMods = false;
        }

        /// <summary>
        /// This function enables / disables a mod and sets the new value in the checkbox of mod info.
        /// </summary>
        /// <param name="enabled">Mod enabled or not</param>
        public void HandleEnableDisableMod(bool enabled)
        {
            string actualModId = EventSystem.current.currentSelectedGameObject.name;
            Mod mod = ModLoader.GetModInstance(actualModId);
            if (mod == null)
                return;

            mod.enabled = enabled;

            ClearList();
            SettingsHandler.GetInstance().LoadMenuOfMod(mod); // To-do optimize this (dont reload, do something faster)
        }

        public static UIHandler GetInstance()
        {
            if (instance == null)
                instance = new UIHandler();
            return instance;
        }
    }
}
