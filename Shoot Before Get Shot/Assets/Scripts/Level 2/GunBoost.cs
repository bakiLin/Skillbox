using UnityEngine;

public class GunBoost : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerAmmo ammo;

    private void Awake()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
        ammo = FindObjectOfType<PlayerAmmo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerShoot.shootTime = 0.35f;
            //ammo.magazineSize = 10;
            //ammo.currentAmmo = 10;
            //ammo.ChangeAmmoUI();

            Destroy(gameObject);
        }
    }
}
