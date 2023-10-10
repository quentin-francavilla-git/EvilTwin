using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        slider.maxValue =FightingEnemy.health;
        slider.value =FightingEnemy.health;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        slider.value = FightingEnemy.health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
