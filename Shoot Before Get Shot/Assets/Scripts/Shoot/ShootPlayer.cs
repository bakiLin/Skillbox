using System.Collections;
using UnityEngine;

public class ShootPlayer : Shoot
{
    [SerializeField] 
    private ShootProgress shootProgress;

    private AnimationPlayer playerAnimation;
    private PlayerAmmo playerAmmo;

    protected override void Awake()
    {
        playerAnimation = GetComponent<AnimationPlayer>();
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
                    playerAnimation.Shoot();

                    Instantiate(bullet, transform.position + transform.right * 0.3f, transform.rotation);
                    playerAmmo.UseAmmo();

                    yield return new WaitForSeconds(shootDelay);
                }
                else
                {
                    playerAnimation.Reload();
                    yield return new WaitForSeconds(shootDelay);
                    playerAmmo.UseAmmo();
                }
            }

            yield return null;
        }
    }
}
