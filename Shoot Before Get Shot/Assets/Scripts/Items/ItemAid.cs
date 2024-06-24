using UnityEngine;

public class ItemAid : MonoBehaviour, IItem
{
    [SerializeField] private int health;

    public void PickItem(PlayerPickItem player)
    {
        if (player.health.IsInjured())
        {
            player.health.PickAid(health);
            Destroy(gameObject);
        }
    }
}
