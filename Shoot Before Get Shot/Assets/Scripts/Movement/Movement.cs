using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] 
    protected float speed;

    protected Rigidbody2D rb;
    protected AnimationParent characterAnimation;
    protected Health health;
    protected Vector3 moveDirection;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<AnimationParent>();
        health = GetComponent<Health>();
    }

    protected virtual void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.fixedDeltaTime * speed * moveDirection);
        rb.velocity = Vector3.zero; //чтобы velocity не двигал врагов при столкновении с персонажем 
    }

    protected virtual void Rotate(float a, float b)
    {
        if (a > b) transform.rotation = Quaternion.Euler(Vector3.zero);
        if (a < b) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    protected virtual void StopMovement()
    {
        moveDirection = Vector3.zero;
        rb.velocity = Vector3.zero;

        Destroy(rb);
        Destroy(this);
    }

    protected virtual void OnEnable() => health.onDeath += StopMovement;

    protected virtual void OnDisable() => health.onDeath -= StopMovement;
}
