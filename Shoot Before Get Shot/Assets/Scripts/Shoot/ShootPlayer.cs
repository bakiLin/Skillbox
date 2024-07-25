using System.Collections;
using UnityEngine;
using Zenject;

public class ShootPlayer : Shoot
{
    [Inject]
    private ShootProgress shootProgress;

    private AnimationPlayer characterAnimation;
    private PlayerAmmo playerAmmo;

    protected override void Awake()
    {
        base.Awake();
        characterAnimation = GetComponent<AnimationPlayer>();
        playerAmmo = GetComponent<PlayerAmmo>();
    }

    protected override IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerAmmo.currentAmmo > 0)
                {
                    shootProgress.ProgressFill(shootDelay);
                    characterAnimation.Shoot();

                    Instantiate(bullet, transform.position + transform.right * 0.3f, transform.rotation);
                    playerAmmo.UseAmmo();

                    yield return new WaitForSeconds(shootDelay);
                }
                else
                {
                    characterAnimation.Reload();
                    yield return new WaitForSeconds(shootDelay);
                    playerAmmo.UseAmmo();
                }
            }

            yield return null;
        }
    }
}
