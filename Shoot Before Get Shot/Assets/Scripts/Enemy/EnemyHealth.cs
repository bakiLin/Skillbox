using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private float maxHealth, deathDuration, currentHealth;

    private Transform healthFillTransform;
    private AnimationEnemy enemyAnimation;

    private void Awake()
    {
        enemyAnimation = GetComponent<AnimationEnemy>();
        healthFillTransform = healthBar.GetComponentsInChildren<Transform>()[1];
    }

    private void Start() => UpdateUI();

    private void UpdateUI()
    {
        Vector3 temp = healthFillTransform.localScale;
        temp.x = currentHealth / maxHealth;
        healthFillTransform.localScale = temp;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateUI();
        if (currentHealth <= 0f) StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        enemyAnimation.DeathAnimation();
        healthBar.SetActive(false);
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }
}
