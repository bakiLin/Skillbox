using UnityEngine;

public class ShootEnemy : Shoot
{
    private bool shoot;

    protected override void ShootAction()
    {
        if (shoot)
        {
            cooldown = shootDelay;
            shoot = false;

            anim.Shoot();
            Vector3 spawnPosition = new Vector3(transform.right.x * 0.2f, -0.07f);
            Instantiate(bullet, transform.position + spawnPosition, transform.rotation);
        }
    }

    public void Shoot(bool state) => shoot = state;
}
