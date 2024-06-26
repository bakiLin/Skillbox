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
        SetHealth();
    }

    public bool IsInjured() => healthCurrent < healthMax;
}
