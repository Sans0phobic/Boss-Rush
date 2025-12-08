using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaneF
{
    public class BarDane : MonoBehaviour
    {
        [SerializeField] Image barFill;

        float maximumValue;
        float currentValue;

        public void Start()
        {
            maximumValue = 60.0f;
            currentValue = maximumValue;
        }

        public void Value() 
        {
            currentValue -= 2.0f;
        }

        public void Update()
        {
            barFill.fillAmount = currentValue / maximumValue;
        }
    }
}