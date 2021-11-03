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
        internal int numberCount;
        internal UnityAction<float> funcToCall;
        public float value;

        public SettingsSlider(float minValue, float maxValue, int numberCount)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
        }

        public SettingsSlider(float minValue, float maxValue, int numberCount, UnityAction<float> funcToCall)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
            this.funcToCall = funcToCall;
        }

        public void HandlerSlider(float value)
        {
            double newValue = Math.Round((double)value, numberCount);
            base.parent.transform.GetChild(1).GetComponent<Text>().text = $"{newValue}";
            this.value = newValue;
        }
    }
}
