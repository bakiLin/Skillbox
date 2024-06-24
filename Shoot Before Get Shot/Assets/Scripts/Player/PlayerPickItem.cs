using UnityEngine;

public class PlayerPickItem : MonoBehaviour
{
    [HideInInspector] public PlayerAmmo ammo;
    [HideInInspector] public HealthPlayer health;

    private void Awake()
    {
        ammo = GetComponent<PlayerAmmo>();
        health = GetComponent<HealthPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.gameObject.GetComponent<IItem>();
        item?.PickItem(this);
    }
}
