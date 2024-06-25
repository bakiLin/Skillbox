public class AnimationEnemy : AnimationParent
{
    public void DeathAnimation() => animator.SetTrigger("isDead");
}
