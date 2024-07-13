using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseWindow;

    [SerializeField]
    private GameObject player;

    private Shoot shoot;
    private Movement movement;

    private void Awake()
    {
        shoot = player.GetComponent<Shoot>();
        movement = player.GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        shoot.StopShooting();
        movement.enabled = false;
        pauseWindow.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        shoot.StartShooting();
        movement.enabled = true;
    }
}
