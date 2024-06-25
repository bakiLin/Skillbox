using UnityEngine;

public class ControlPlayerAnimation : MonoBehaviour, IControl
{
    [SerializeField] private MovementPlayer movement;

    public void StartMovement() => movement.enabled = true;

    public void StopMovement() => movement.enabled = false;
}
