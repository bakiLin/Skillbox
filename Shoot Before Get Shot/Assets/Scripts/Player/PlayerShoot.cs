using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootDelay;
    [SerializeField] private ShootProgress shootProgress;

    private PlayerAnimation playerAnimation;
    private PlayerAmmo playerAmmo;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerAmmo = GetComponent<PlayerAmmo>();
    }

    private void Start() => StartCoroutine(ShootCoroutine());

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerAmmo.currentAmmo > 0)
                {
                    shootProgress.ProgressFill(shootDelay);
                    playerAnimation.Shoot();

                    Vector3 bulletSpawnPosition = transform.position + transform.right * 0.3f;
                    Instantiate(bullet, bulletSpawnPosition, transform.rotation);

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
