using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour, IHealth
{
    [SerializeField] private Slider slider;
    [SerializeField] private float healthMax, healthCurrent;

    private void Start()
    {
        SetHealth();
    }

    public void SetHealth() => slider.value = healthCurrent / healthMax;

    public void TakeDamage(int damage)
    {
        healthCurrent -= damage;
        SetHealth();
    }

    public void PickAid(int health)
    {
        healthCurrent += health;
        SetHealth();
    }

    public bool IsInjured() => healthCurrent < healthMax;

    //[SerializeField] private LevelManager levelManager;
    //[SerializeField] private Slider healthSlider;

    //public float maxHp, currentHp;

    //private bool dead;

    //private void Start() => healthSlider.value = currentHp / maxHp;

    //public void Heal(int hp)
    //{
    //    currentHp += hp;
    //    if (currentHp > maxHp) currentHp = maxHp;
    //    healthSlider.value = currentHp / maxHp;
    //}

    //public void TakeDamage(float damage)
    //{
    //    if (!dead)
    //    {
    //        currentHp -= damage;
    //        healthSlider.value = currentHp / maxHp;

    //        if (currentHp <= 0)
    //        {
    //            dead = true;
    //            PlayerPrefs.SetFloat("music", 0f);
    //            levelManager.StartDeath();
    //        }
    //    }
    //}
}
