using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void RunAnimation(bool state) => animator.SetBool("isRunning", state);

    public void DeathAnimation() => animator.SetTrigger("isDead");

    public void ShootAnimation() => animator.SetTrigger("Shoot");
}
