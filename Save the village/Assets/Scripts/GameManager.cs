using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Units")]
    public int WorkerCount;
    public int WarriorCount;

    [Header("Worker")]
    public int WorkerPrice;
    public float WorkerSpawnTime;

    [Header("Warrior")]
    public int WarriorPrice;
    public float WarriorSpawnTime;

    [Header("Wheat")]
    public int WheatCount;
    public float WheatProduceTime;
    public int WheatPerCycle;
    public int WheatConsumeNumber;
    public float WheatConsumeTime;

    [Header("Win Condition")]
    public int WheatWinNumber;
    public int WorkerWinNumber;

    [Header("UI")]
    public float MessageHungerTime;
    public GameObject GameOverWindow;
    public GameObject WinWindow;

    [Header("Enemy Wave")]
    public float[] TimeBeforeWave;
    public int[] EnemyNumberInWave;

    [Header("Text Field")]
    public TextMeshProUGUI WheatText;
    public TextMeshProUGUI WorkerText;
    public TextMeshProUGUI WarriorText;
    [Space]
    public TextMeshProUGUI WorkerPriceTag;
    public TextMeshProUGUI WarriorPriceTag;
    [Space]
    public TextMeshProUGUI WheatProduceInfo;
    public TextMeshProUGUI WheatConsumeInfo;
    [Space]
    public TextMeshProUGUI Status;
    [Space]
    public TextMeshProUGUI WaveNumberText;
    public TextMeshProUGUI EnemyNumberText;
    [Space]
    public TextMeshProUGUI ConditionWheat;
    public TextMeshProUGUI ConditionWorker;

    [Header("Icon fill bar")]
    public Image WheatBar;
    public Image WorkerBar;
    public Image WarriorBar;
    public Image ConsumeBar;
    public Image EnemyWaveBar;

    private void Start()
    {
        WheatText.text = WheatCount.ToString();
        WorkerText.text = WorkerCount.ToString();
        WarriorText.text = WarriorCount.ToString();
        WorkerPriceTag.text = WorkerPrice.ToString();
        WarriorPriceTag.text = WarriorPrice.ToString();
        ConditionWheat.text = WheatWinNumber.ToString();
        ConditionWorker.text = WorkerWinNumber.ToString();
    }
}
