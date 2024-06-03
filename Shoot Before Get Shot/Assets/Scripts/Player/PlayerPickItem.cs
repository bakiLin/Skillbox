using UnityEngine;

public class PlayerPickItem : MonoBehaviour
{
    [SerializeField] private int ammo;
    [SerializeField] private int hp; 

    private PlayerAmmo ammoScript;
    private PlayerHealth healthScript;

    private void Awake()
    {
        ammoScript = GetComponent<PlayerAmmo>();
        healthScript = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            ammoScript.totalAmmo += ammo;
            ammoScript.ChangeAmmoUI();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("First Aid"))
        {
            if (healthScript.maxHp != healthScript.currentHp)
            {
                healthScript.Heal(hp);
                Destroy(collision.gameObject);
            }
        }
    }
}
