using System.Collections;
using TMPro;
using UnityEngine;

public class ChallengeTimer : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int timeToSurvive;

    private Spawning spawn;
    private ChallengeZone challengeZone;

    private void Awake()
    {
        spawn = GetComponent<Spawning>();
        challengeZone = GetComponent<ChallengeZone>();
    }

    public void StartTimer() => StartCoroutine(Timer());

    private IEnumerator Timer()
    {
        while (true)
        {
            if (spawn.player != null)
            {
                timerText.text = $"Time: {timeToSurvive}";
                yield return new WaitForSeconds(1f);
                timeToSurvive -= 1;

                if (timeToSurvive == 0)
                {
                    ChallengeOver();
                    break;
                }
            }

            yield return null;
        }
    }

    public void ChallengeOver()
    {
        timerText.text = "Victory";
        Destroy(spawn);
        Destroy(challengeZone.wall);
        StopAllEnemy();
        levelManager.StartLoadLevel(0, 3);
        Destroy(gameObject);
    }

    private void StopAllEnemy()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        foreach (EnemyMovement enemy in enemies)
            enemy.enabled = false;
    }
}
