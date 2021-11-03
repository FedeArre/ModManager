using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace ModManager
{
    class SettingsSlider : Settings
    {
        internal float minValue;
        internal float maxValue;
        internal UnityAction<float> funcToCall;
        public readonly float value;

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

        public static void HandlerSlider(float value)
        {

        }
    }
}
