using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Run(Vector3 movement) => animator.SetFloat("speed", movement.magnitude);

    public void Shoot() => animator.SetTrigger("shoot");

    public void Reload() => animator.SetTrigger("reload");

    public void DeathAnimation() => animator.SetBool("PlayerDeath", true);
}
