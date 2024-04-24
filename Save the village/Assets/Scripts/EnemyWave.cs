using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    private GameManager gameManager;
    private float time;
    private int waveNumber;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        waveNumber = 0;
        time = gameManager.TimeBeforeWave[waveNumber];
        gameManager.WaveNumberText.text = $"{waveNumber + 1}\\{gameManager.TimeBeforeWave.Length}";
        gameManager.EnemyNumberText.text = gameManager.EnemyNumberInWave[waveNumber].ToString();
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            if (gameManager.WarriorCount >= gameManager.EnemyNumberInWave[waveNumber])
            {
                gameManager.WarriorCount -= gameManager.EnemyNumberInWave[waveNumber];
                gameManager.WarriorText.text = gameManager.WarriorCount.ToString();
                gameManager.WheatConsumeInfo.text = (gameManager.WarriorCount * gameManager.WheatConsumeNumber).ToString();

                if (gameManager.TimeBeforeWave.Length > waveNumber + 1)
                {
                    waveNumber += 1;
                    time = gameManager.TimeBeforeWave[waveNumber];
                    gameManager.WaveNumberText.text = $"{waveNumber + 1}\\{gameManager.TimeBeforeWave.Length}";
                    gameManager.EnemyNumberText.text = gameManager.EnemyNumberInWave[waveNumber].ToString();
                }
                else 
                {
                    gameManager.WinWindow.SetActive(true);
                    Time.timeScale = 0;
                } 
            }
            else
            {
                gameManager.GameOverWindow.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public float EnemyWaveBarPercent() => 1 - time / gameManager.TimeBeforeWave[waveNumber];
}
