using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField]
    private Movement movement;

    private void StartMovement() => movement.enabled = true;
    private void StopMovement() => movement.enabled = false;
}
