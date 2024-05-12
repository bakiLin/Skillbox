using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private float movement;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement < 0) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        if (movement > 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        animator.SetFloat("runSpeed", Mathf.Abs(movement));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
