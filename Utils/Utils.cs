using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModManager
{
    public class Utils
    {
        public static string MODS_FOLDER_PATH = Application.dataPath + "/../Mods";
        public static string MODS_SETTINGS_FOLDER_PATH = MODS_FOLDER_PATH + "/modSettings";

        /// <summary>
        /// This function is used for getting a setting in a list using his id.
        /// </summary>
        /// <param name="list">List of settings to check</param>
        /// <param name="id">The id of the setting</param>
        /// <returns>The setting object (base) if exists, null otherwise </returns>
        internal static Settings GetSettingByIdInList(List<Settings> list, string id)
        {
            foreach(Settings s in list)
            {
                if (s.id == id)
                    return s;
            }

            return null;
        }

        /// <summary>
        /// This function searches for a Mod with the provided id in the mods that are loaded. Note that using ModLoader.GetModInstance is not the same since it returns null if the mod is disabled
        /// </summary>
        /// <param name="modId">The id of the mod</param>
        /// <returns>The mod instance if the id exists, null otherwise</returns>
        internal static Mod GetModById(string modId)
        {
            foreach (Mod mod in ModLoader.mods)
            {
                if (mod.ID == modId)
                    return mod;
            }

            return null;
        }
    }
}
