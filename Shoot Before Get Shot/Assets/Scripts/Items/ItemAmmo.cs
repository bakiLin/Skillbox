using UnityEngine;

public class ItemAmmo : MonoBehaviour, IItem
{
    [SerializeField] private int ammo;

    public void PickItem(PlayerPickItem player)
    {
        player.ammo.PickAmmo(ammo);
        Destroy(gameObject);
    }
}
