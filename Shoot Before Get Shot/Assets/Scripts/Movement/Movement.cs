using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] 
    protected float speed;

    protected Rigidbody2D rb;
    protected AnimManager animManager;
    protected Health health;
    protected Vector3 moveDirection;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animManager = GetComponent<AnimManager>();
        health = GetComponent<Health>();
    }

    protected virtual void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.fixedDeltaTime * speed * moveDirection);
        rb.Sleep();
    }

    protected virtual void Rotate(float a, float b)
    {
        if (a > b) transform.rotation = Quaternion.Euler(Vector3.zero);
        if (a < b) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    protected virtual void Death()
    {
        rb.Sleep();
        Destroy(rb);
    }
}
