using System.Collections;
using UnityEngine;

public class ShootEnemy : Shoot
{
    private bool shoot, delay;
    private AnimationParent characterAnimation;

    protected override void Awake()
    {
        base.Awake();
        characterAnimation = GetComponent<AnimationParent>();
    }

    protected override IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (!delay & shoot)
            {
                delay = true;

                characterAnimation.Shoot();
                Vector3 spawnPosition = new Vector3(transform.right.x * 0.2f, -0.07f);
                Instantiate(bullet, transform.position + spawnPosition, transform.rotation);
                yield return new WaitForSeconds(shootDelay);

                delay = false;
                shoot = false;
            }

            yield return null;
        }
    }

    public void Shoot() => shoot = true;
}
