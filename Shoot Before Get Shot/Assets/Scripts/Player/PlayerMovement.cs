using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private PlayerAnimation playerAnimation;
    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        PlayerRotate();
        playerAnimation.RunAnimation(movement);

        if (movement != Vector3.zero)
            playerAnimation.RunAnimation(movement);
            
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * movement);
        rb.velocity = Vector3.zero;
    }

    private void PlayerRotate()
    {
        if (movement.x != 0)
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = movement.x < 0 ? 180f : 0f;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
