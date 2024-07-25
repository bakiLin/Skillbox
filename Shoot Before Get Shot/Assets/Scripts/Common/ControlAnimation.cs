using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    private Movement movement;

    private void Awake() => movement = transform.parent.GetComponent<Movement>();

    private void StartMovement() => movement.enabled = true;

    private void StopMovement() => movement.enabled = false;

    private void Death() => Destroy(movement.gameObject);
}
