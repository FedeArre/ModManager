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
        internal double defaultValue;
        internal UnityAction<float> funcToCall;
        public double value;

        public SettingsSlider(float minValue, float maxValue, int numberCount)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
            defaultValue = minValue;
        }
        public SettingsSlider(float minValue, float maxValue, int numberCount, double defaultValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
            this.defaultValue = defaultValue;
        }

        public SettingsSlider(float minValue, float maxValue, int numberCount, double defaultValue, UnityAction<float> funcToCall)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.numberCount = numberCount;
            this.funcToCall = funcToCall;
            this.defaultValue = defaultValue;
        }

        public void HandlerSlider(float value)
        {
            double newValue = Math.Round((double)value, numberCount);
            base.parent.transform.GetChild(1).GetComponent<Text>().text = $"{newValue}";
            this.value = newValue;
        }
    }
}
