using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Slider healthSlider;

    public float maxHp, currentHp;

    private bool dead;

    private void Start() => healthSlider.value = currentHp / maxHp;

    public void Heal(int hp)
    {
        currentHp += hp;
        if (currentHp > maxHp) currentHp = maxHp;
        healthSlider.value = currentHp / maxHp;
    }

    public void TakeDamage(float damage)
    {
        if (!dead)
        {
            currentHp -= damage;
            healthSlider.value = currentHp / maxHp;

            if (currentHp <= 0)
            {
                dead = true;
                PlayerPrefs.SetFloat("music", 0f);
                levelManager.StartDeath();
            }
        }
    }
}
