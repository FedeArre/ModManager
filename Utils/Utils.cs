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

        public static Settings GetSettingByIdInList(List<Settings> list, string id)
        {
            foreach(Settings s in list)
            {
                if (s.id == id)
                    return s;
            }

            return null;
        }
    }
}
