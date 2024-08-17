using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ResourceManager : MonoBehaviour
{
    [Inject]
    private PlayerAmmo playerAmmo;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            PlayerPrefs.DeleteAll();
    }

    public void Save()
    {
        SaveAmmo();
    }

    private void SaveAmmo()
    {
        int[] ammo = playerAmmo.GetAmmo();

        PlayerPrefs.SetInt("mag", ammo[0]);
        PlayerPrefs.SetInt("total", ammo[1]);
    }
}
