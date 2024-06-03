using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] shootBarComponents;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime;

    public float shootTime;

    private PlayerAmmo playerAmmo;
    private PlayerAnimation playerAnimation;
    private float cooldown;

    private const float progressScaleX = 3.3f;

    private void Awake()
    {
        playerAmmo = GetComponent<PlayerAmmo>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Start() => StartCoroutine(Shoot());

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerAmmo.currentAmmo > 0)
                {
                    ShootBarState(true);

                    playerAmmo.Shoot();
                    playerAnimation.ShootAnimation();

                    Instantiate(bullet, transform.position + transform.right, transform.rotation);
                    yield return new WaitForSeconds(shootTime);

                    ShootBarState(false);
                    cooldown = 0f;
                }
                else
                {
                    playerAnimation.ReloadAnimation();
                    yield return new WaitForSeconds(reloadTime);
                    playerAmmo.Reload();
                }
            }
            yield return null;
        }
    }

    private void ShootBarState(bool state)
    {
        foreach (GameObject temp in shootBarComponents)
            temp.SetActive(state);
    }

    private void Update()
    {
        if (shootBarComponents[0].activeSelf)
        {
            cooldown += Time.deltaTime;
            Vector3 temp = shootBarComponents[0].transform.localScale;
            temp.x = progressScaleX * cooldown / shootTime;
            shootBarComponents[0].transform.localScale = temp;
        }
    }
}
