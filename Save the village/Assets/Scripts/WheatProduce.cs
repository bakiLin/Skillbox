using UnityEngine;

public class WheatProduce : MonoBehaviour
{
    private GameManager gameManager;

    private float timeToProduce;
    private float timeToConsume;

    private float fadeInTime;
    private float fadeOutTime;

    private bool warriorDied;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        timeToProduce = gameManager.WheatProduceTime;
        timeToConsume = gameManager.WheatConsumeTime;
        fadeInTime = gameManager.MessageHungerTime;
    }

    private void Update()
    {
        if (gameManager.WorkerCount > 0)
            Produce();

        if (gameManager.WarriorCount > 0)
            Consume();

        if (warriorDied)
            StatusText();

        gameManager.WheatText.text = gameManager.WheatCount.ToString();
    }

    private void Produce()
    {
        if (timeToProduce > 0)
            timeToProduce -= Time.deltaTime;
        else
        {
            timeToProduce = gameManager.WheatProduceTime;
            gameManager.WheatCount += gameManager.WorkerCount * gameManager.WheatPerCycle;

            if (gameManager.WheatCount >= gameManager.WheatWinNumber &&
                gameManager.WorkerCount >= gameManager.WorkerWinNumber)
            {
                gameManager.WheatText.text = gameManager.WheatCount.ToString();
                gameManager.WinWindow.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void Consume()
    {
        if (timeToConsume > 0)
            timeToConsume -= Time.deltaTime;
        else
        {
            timeToConsume = gameManager.WheatConsumeTime;
            gameManager.WheatCount -= gameManager.WarriorCount * gameManager.WheatConsumeNumber;

            if (gameManager.WheatCount < 0)
            {
                gameManager.WheatCount = 0;
                warriorDied = true;

                gameManager.WarriorCount -= 1;
                gameManager.WarriorText.text = gameManager.WarriorCount.ToString();
                gameManager.WheatConsumeInfo.text = (gameManager.WarriorCount * gameManager.WheatConsumeNumber).ToString();
            }
        }
    }

    private void StatusText()
    {
        Color color = gameManager.Status.color;

        if (fadeInTime > 0)
        {
            fadeInTime -= Time.deltaTime;
            gameManager.Status.color = new Color(color.r, color.g, color.b, 1 - fadeInTime / gameManager.MessageHungerTime);
        }
        else if (fadeOutTime < gameManager.MessageHungerTime)
        {
            fadeOutTime += Time.deltaTime;
            gameManager.Status.color = new Color(color.r, color.g, color.b, 1 - fadeOutTime / gameManager.MessageHungerTime);
        }
        else
        {
            warriorDied = false;
            fadeInTime = gameManager.MessageHungerTime;
            fadeOutTime = 0f;
        }
    }

    public float WheatBarPercent() => 1 - timeToProduce / gameManager.WheatProduceTime;

    public float ConsumeBarPercent() => 1 - timeToConsume / gameManager.WheatConsumeTime;
}
