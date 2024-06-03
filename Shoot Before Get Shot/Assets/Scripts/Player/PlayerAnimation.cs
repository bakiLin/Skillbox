using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void RunAnimation(Vector3 movement) => animator.SetFloat("PlayerSpeed", movement.magnitude);

    public void ShootAnimation() => animator.SetTrigger("PlayerShoot");

    public void ReloadAnimation() => animator.SetTrigger("PlayerReload");

    public void DeathAnimation() => animator.SetBool("PlayerDeath", true);
}
