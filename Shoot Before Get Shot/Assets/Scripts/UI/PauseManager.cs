using UnityEngine;
using Zenject;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseWindow, player;

    [Inject]
    private ShootPlayer shootPlayer;

    [Inject]
    private MovementPlayer movementPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        shootPlayer.StopShooting();
        movementPlayer.enabled = false;
        pauseWindow.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        shootPlayer.StartShooting();
        movementPlayer.enabled = true;
    }
}
