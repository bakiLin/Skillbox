using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : Health
{
    [SerializeField] 
    private Slider slider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("hp")) 
            healthCurrent = PlayerPrefs.GetFloat("hp");

        SetHealth();
    }

    protected override void SetHealth() => slider.value = healthCurrent / healthMax;

    public void PickAid(int health)
    {
        healthCurrent += health;

        if (healthCurrent > 100f)
            healthCurrent = 100f;

        SetHealth();
    }

    public bool IsInjured() => healthCurrent < healthMax;

    public float GetHealth() => healthCurrent;
}
