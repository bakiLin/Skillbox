public class AnimationPlayer : AnimationParent
{
    public void Reload() => animator.SetTrigger("reload");

    public void DeathAnimation() => animator.SetBool("PlayerDeath", true);
}
