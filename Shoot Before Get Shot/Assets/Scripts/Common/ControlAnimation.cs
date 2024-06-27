using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField]
    private Movement movement;

    private Transform character;

    private void Awake() => character = movement.transform.parent;

    private void StartMovement()
    {
        if (movement != null) 
            movement.enabled = true;
    }

    private void StopMovement()
    {
        if (movement != null)
            movement.enabled = false;
    }

    private void Death() 
    {
        Destroy(character.gameObject);
    }
}
