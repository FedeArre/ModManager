using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModManager
{
    public class SettingsSlider : Settings
    {
        internal float minValue;
        internal float maxValue;
        internal UnityAction<float> funcToCall;
        public float value;

        public SettingsSlider(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public SettingsSlider(float minValue, float maxValue, UnityAction<float> funcToCall)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.funcToCall = funcToCall;
        }

        public void HandlerSlider(float value)
        {
            base.parent.transform.GetChild(1).GetComponent<Text>().text = $"{value}";
            this.value = value;
        }
    }
}
