using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damageNumber;

    private EnemyHealth health;

    private void Awake() => health = GetComponent<EnemyHealth>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health.TakeDamage(damageNumber);
            Destroy(collision.gameObject);
        }
    }
}
