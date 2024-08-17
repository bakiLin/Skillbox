using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    private Movement movement;
    private GameObject player;

    private void Awake()
    {
        movement = transform.parent.GetComponent<Movement>();
        player = movement.gameObject;
    }

    private void StartMovement() => movement.enabled = true;

    private void StopMovement() => movement.enabled = false;

    private void Death() => Destroy(player);
}
