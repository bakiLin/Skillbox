using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float radius;
    [SerializeField] private Transform groundCollider;
    [SerializeField] private LayerMask groundMask;

    private Transform platformPosition = null;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool jumped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
            jumped = true;

        animator.SetFloat("velocityY", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCollider.position, radius, groundMask);

        if (platformPosition != null)
        {
            if (transform.position.y < platformPosition.position.y + 1)
                isGrounded = false;
        }

        if (jumped)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumped = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
            platformPosition = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
            platformPosition = null;
    }
}
