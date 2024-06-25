using UnityEngine;

public abstract class AnimationParent : MonoBehaviour
{
    [SerializeField] 
    protected Animator animator;

    public virtual void Run(Vector3 moveDirection) => animator.SetFloat("speed", moveDirection.magnitude);

    public virtual void Shoot() => animator.SetTrigger("shoot");
}
