using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private enum Target
    {
        Player,
        Enemy
    }

    [SerializeField] 
    private int damage;

    [SerializeField]
    private Target target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (collision.CompareTag(target.ToString()))
        {
            health?.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
