using System.Collections;
using UnityEngine;

namespace ModManager
{
    public class KeybindHelper : MonoBehaviour
    {
        internal SettingsKeybind parentSetting;

        private bool stop;

        private int[] values;

        void Start()
        {
            values = (int[])System.Enum.GetValues(typeof(KeyCode));
        }

        void Update()
        {
            for (int i = 0; i < values.Length || !stop; i++) // In testing sometimes was being called after GameObject.Destroy. Seems like Unity doesn't destroy the objects in the same frame and that causes the issue.
            {
                if (Input.GetKey((KeyCode)values[i]))
                {
                    parentSetting.FoundNewKey(values[i]);
                    stop = true;
                    return;
                }
            }
        }
    }
}