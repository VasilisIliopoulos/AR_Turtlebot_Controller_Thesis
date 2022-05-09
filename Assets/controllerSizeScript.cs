using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    public class controllerSizeScript : MonoBehaviour
    {
        [SerializeField]
        private Transform transformSize = null;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            if (transformSize != null)
            {
                // Rotate the target object using Slider's eventData.NewValue
                transformSize.localScale = new Vector3(0.10f + eventData.NewValue / 10.0f, 0.10f + eventData.NewValue / 10.0f, 0.10f + eventData.NewValue/10.0f);
            }
        }
    }
}
