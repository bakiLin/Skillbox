using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private PlayerAnimation playerAnimation;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        Rotate();
        playerAnimation.Run(movement);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);
    }

    private void Rotate()
    {
        if (movement.x > 0)
            transform.rotation = Quaternion.Euler(Vector2.zero);

        if (movement.x < 0)
            transform.rotation = Quaternion.Euler(new Vector2(0f, 180f));
    }
}
