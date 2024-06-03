using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;

    [HideInInspector] public int currentAmmo;

    public int totalAmmo, magazineSize;

    private void Start()
    {
        currentAmmo = magazineSize;
        ChangeAmmoUI();
    }

    public void Shoot()
    {
        currentAmmo -= 1;
        ChangeAmmoUI();
    }

    public void Reload()
    {
        if (totalAmmo > magazineSize) currentAmmo = magazineSize;
        else currentAmmo = totalAmmo;

        totalAmmo -= magazineSize;
        if (totalAmmo < 0) totalAmmo = 0;

        ChangeAmmoUI();
    }

    public void ChangeAmmoUI() => ammoText.text = $"{currentAmmo}/{totalAmmo}";
}
