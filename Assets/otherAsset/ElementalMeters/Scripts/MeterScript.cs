using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TIME_MANAGER time_manager;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate (1f) ;

    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void Update()
    {
        slider.value = time_manager.debug_slider.value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
