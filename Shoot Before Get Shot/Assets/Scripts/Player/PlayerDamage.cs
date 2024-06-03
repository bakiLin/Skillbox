using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damageNumber;

    private PlayerHealth health;

    private void Awake() => health = GetComponent<PlayerHealth>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Bullet"))
        {
            health.TakeDamage(damageNumber);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
            health.TakeDamage(damageNumber);
    }
}
