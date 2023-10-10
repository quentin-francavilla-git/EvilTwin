using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        slider.maxValue = PlayerVariables.maxHealth;
        slider.value = PlayerVariables.currentHealth;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        slider.value = PlayerVariables.currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
