using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI ammoText;

    [SerializeField] 
    private int magazine, totalAmmo;

    [HideInInspector] 
    public int currentAmmo;

    private void Start()
    {
        if (PlayerPrefs.HasKey("mag")) currentAmmo = PlayerPrefs.GetInt("mag");
        else currentAmmo = magazine;

        if (PlayerPrefs.HasKey("total")) totalAmmo = PlayerPrefs.GetInt("total");

        ammoText.text = $"{currentAmmo}/{totalAmmo}";
    }

    public void UseAmmo()
    {
        if (currentAmmo > 0)
            currentAmmo -= 1;
        else
        {
            if (totalAmmo > magazine)
            {
                currentAmmo += magazine;
                totalAmmo -= magazine;
            }
            else
            {
                currentAmmo += totalAmmo;
                totalAmmo = 0;
            }
        }

        ammoText.text = $"{currentAmmo}/{totalAmmo}";
    }

    public void PickAmmo(int ammo)
    {
        totalAmmo += ammo;
        ammoText.text = $"{currentAmmo}/{totalAmmo}";
    }

    public int[] GetAmmo() => new int[] { currentAmmo, totalAmmo };
}
