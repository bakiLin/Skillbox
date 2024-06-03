using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootTime;

    private EnemyAnimation enemyAnimation;
    private bool shoot;

    private void Awake() => enemyAnimation = GetComponent<EnemyAnimation>();

    public void Shoot()
    {
        if (!shoot)
        {
            shoot = true;
            enemyAnimation.ShootAnimation();
            Instantiate(bullet, transform.position + transform.right, transform.rotation);

            StopAllCoroutines();
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootTime);
        shoot = false;
    }
}
