using UnityEngine;

public class UnitCooldown : MonoBehaviour
{
    private GameManager gameManager;

    private float workerTime = -10f;
    private float warriorTime = -10f;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        gameManager.WheatProduceInfo.text = (gameManager.WorkerCount * gameManager.WheatPerCycle).ToString();
        gameManager.WheatConsumeInfo.text = (gameManager.WarriorCount * gameManager.WheatConsumeNumber).ToString();
    }

    private void Update()
    {
        WorkerTimer();
        WarriorTimer();
    }

    private void WorkerTimer()
    {
        if (workerTime > 0)
            workerTime -= Time.deltaTime;
        else if (workerTime > -1f)
        {
            workerTime = -10f;

            gameManager.WorkerCount += 1;
            gameManager.WorkerText.text = gameManager.WorkerCount.ToString();
            gameManager.WheatProduceInfo.text = (gameManager.WorkerCount * gameManager.WheatPerCycle).ToString();

            if (gameManager.WheatCount >= gameManager.WheatWinNumber &&
            gameManager.WorkerCount >= gameManager.WorkerWinNumber)
            {
                gameManager.WinWindow.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void WarriorTimer()
    {
        if (warriorTime > 0)
            warriorTime -= Time.deltaTime;
        else if (warriorTime > -1f)
        {
            warriorTime = -10f;

            gameManager.WarriorCount += 1;
            gameManager.WarriorText.text = gameManager.WarriorCount.ToString();
            gameManager.WheatConsumeInfo.text = (gameManager.WarriorCount * gameManager.WheatConsumeNumber).ToString();
        }
    }

    public void BuyWorker()
    {
        if (gameManager.WheatCount >= gameManager.WorkerPrice && workerTime < -1f)
        {
            workerTime = gameManager.WorkerSpawnTime;
            gameManager.WheatCount -= gameManager.WorkerPrice;
            gameManager.WheatText.text = gameManager.WheatCount.ToString();
        }
    }

    public void BuyWarrior()
    {
        if (gameManager.WheatCount >= gameManager.WarriorPrice && warriorTime < -1f)
        {
            warriorTime = gameManager.WarriorSpawnTime;
            gameManager.WheatCount -= gameManager.WarriorPrice;
            gameManager.WheatText.text = gameManager.WheatCount.ToString();
        }
    }

    public float WorkerBarPercent()
    {
        if (workerTime < -1f) return 0f;
        else return 1 - workerTime / gameManager.WorkerSpawnTime;
    }

    public float WarriorBarPercent()
    {
        if (warriorTime < -1f) return 0f;
        else return 1 - warriorTime / gameManager.WarriorSpawnTime;
    }
}
