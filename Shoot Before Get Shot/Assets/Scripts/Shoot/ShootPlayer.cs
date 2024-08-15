using UnityEngine;
using Zenject;

public class ShootPlayer : Shoot
{
    [Inject]
    private ShootProgress shootProgress;

    private PlayerAmmo playerAmmo;

    protected override void Awake()
    {
        base.Awake();
        playerAmmo = GetComponent<PlayerAmmo>();
    }

    protected override void ShootAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cooldown = shootDelay;

            if (playerAmmo.currentAmmo > 0)
            {
                shootProgress.ProgressFill(shootDelay);
                anim.Shoot();

                Instantiate(bullet, transform.position + transform.right * 0.3f, transform.rotation);
                playerAmmo.UseAmmo();
            }
            else
            {
                anim.Reload();
                playerAmmo.UseAmmo();
            }
        }
    }
}
