using UnityEngine;

public class MovementPlayer : Movement
{
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();

        Rotate(moveDirection.x, 0f);
        animManager.Run(moveDirection);
    }
}
