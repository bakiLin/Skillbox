using UnityEngine;

public class MovementPlayer : Movement
{
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();

        Rotate(moveDirection.x, 0f);
        characterAnimation.Run(moveDirection);

        ///
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.15f);

        //if (hit)
        //{
        //    if (hit.collider.CompareTag("Enemy"))
        //    {
        //        moveDirection.x = 0f;
        //    }
        //}

        //Debug.DrawRay(transform.position, transform.right * 0.15f, Color.red);
        ///
    }
}
