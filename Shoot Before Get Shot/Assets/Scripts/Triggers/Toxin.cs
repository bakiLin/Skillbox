using UnityEngine;

public class Toxin : MonoBehaviour
{
    [SerializeField]
    private float damageMultiplier;

    private Health player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player = collision.GetComponent<Health>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player = null;
    }

    private void Update()
    {
        if (player != null)
            player.TakeDamage(Time.deltaTime * damageMultiplier);
    }
}
