using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : Health
{
    [SerializeField] 
    private Slider slider;

    protected override void SetHealth() => slider.value = healthCurrent / healthMax;

    public void PickAid(int health)
    {
        healthCurrent += health;

        if (healthCurrent > 100f)
            healthCurrent = 100f;

        SetHealth();
    }

    public bool IsInjured() => healthCurrent < healthMax;
}
