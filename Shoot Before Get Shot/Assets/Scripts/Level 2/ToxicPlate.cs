using UnityEngine;

public class ToxicPlate : MonoBehaviour
{
    [SerializeField] private float damageMultiplier;

    private PlayerHealth playerHealth;
    private bool playerIn;

    private void Awake() => playerHealth = FindObjectOfType<PlayerHealth>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            playerIn = false;
    }

    private void Update()
    {
        if (playerIn) 
            playerHealth.TakeDamage(Time.deltaTime * damageMultiplier);
    }
}
