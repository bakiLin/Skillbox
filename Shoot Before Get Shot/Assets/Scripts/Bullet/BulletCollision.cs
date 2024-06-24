using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth health = collision.GetComponent<IHealth>();

        if (collision.CompareTag("Player") && gameObject.CompareTag("Bullet Enemy") ||
            collision.CompareTag("Enemy") && gameObject.CompareTag("Bullet Player"))
        {
            health?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
