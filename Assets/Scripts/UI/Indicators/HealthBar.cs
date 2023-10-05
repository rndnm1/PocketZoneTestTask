using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private HealthComponent healthComponentToVisualize;

        private void Awake()
        {
            healthComponentToVisualize.OnDamageRecieved += ValueChanged;
        }

        public void ValueChanged() => healthSlider.value = healthComponentToVisualize.CurrentHP / healthComponentToVisualize.MaxHP;
    }
}
