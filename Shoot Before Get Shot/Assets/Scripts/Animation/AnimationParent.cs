using UnityEngine;

public class AnimationParent : MonoBehaviour
{
    [SerializeField] 
    protected Animator animator;

    protected Health health;

    protected virtual void Awake() => health = GetComponent<Health>();

    public virtual void Run(Vector3 moveDirection) => animator.SetFloat("speed", moveDirection.magnitude);

    public virtual void Shoot() => animator.SetTrigger("shoot");

    protected virtual void Death()
    {
        animator.SetTrigger("death");
        Destroy(this);
    }

    protected virtual void OnEnable() => health.onDeath += Death;

    protected virtual void OnDisable() => health.onDeath -= Death;
}
