public class AnimationPlayer : AnimationParent
{
    public void Reload() => animator.SetTrigger("reload");
}
