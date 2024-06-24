using UnityEngine;

public class ControlPlayerAnimation : MonoBehaviour, IControl
{
    [SerializeField] private PlayerMovement movement;

    public void StartMovement() => movement.enabled = true;

    public void StopMovement() => movement.enabled = false;
}
