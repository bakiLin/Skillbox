using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }
}
