using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseWindow;

    [SerializeField]
    private ShootPlayer shoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void Pause()
    {
        shoot.StopShooting();
        Time.timeScale = 0f;
        pauseWindow.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        shoot.StartShooting();
    }
}
