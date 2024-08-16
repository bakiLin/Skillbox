using UnityEngine;

public class MovementPlayer : Movement
{
    //private Vector2 moveDirection;
    //private AnimManager animManager;

    private const float stopDistance = 0.1f;

    //private void Awake()
    //{
    //    animManager = GetComponent<AnimManager>();
    //}

    void Update()
    {
        //moveDirection.x = Input.GetAxisRaw("Horizontal");
        //moveDirection.y = Input.GetAxisRaw("Vertical");
        //moveDirection.Normalize();

        //Rotate(moveDirection.x, 0f);
        //characterAnimation.Run(moveDirection);

        Move();
    }

    private void Move()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        Rotate(moveDirection.x, 0f);

        animManager.Run(moveDirection);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, stopDistance);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, stopDistance);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, stopDistance);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, stopDistance);

        if (hitLeft && moveDirection.x < 0 || hitRight && moveDirection.x > 0) moveDirection.x = 0f;
        if (hitUp && moveDirection.y > 0 || hitDown && moveDirection.y < 0) moveDirection.y = 0f;

        transform.Translate(Time.deltaTime * moveDirection.normalized, Space.World);
    }
}
