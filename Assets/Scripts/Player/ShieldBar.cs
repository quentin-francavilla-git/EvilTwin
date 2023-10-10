using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    private void Awake()
    {
        slider.maxValue = PlayerVariables.maxShield;
        slider.value = PlayerVariables.currentShield;
    }

    private void Update()
    {
        slider.value = PlayerVariables.currentShield;
    }
}
