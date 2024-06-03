using UnityEngine;

public class ChallengeZone : MonoBehaviour
{
    [SerializeField] private GameObject timerText;

    public GameObject wall;

    private Spawning spawn;
    private ChallengeTimer timer;

    private void Awake()
    {
        spawn = GetComponent<Spawning>();
        timer = GetComponent<ChallengeTimer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timerText.SetActive(true);
            wall.SetActive(true);

            spawn.StartSpawn();
            timer.StartTimer();

            Destroy(this);
        }
    }
}
