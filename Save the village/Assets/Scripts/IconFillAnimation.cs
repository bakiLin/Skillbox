using UnityEngine;

public class IconFillAnimation : MonoBehaviour
{
    private GameManager gameManager;
    private WheatProduce wheatProduce;
    private UnitCooldown unitCooldown;
    private EnemyWave enemyWave;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        wheatProduce = GetComponent<WheatProduce>();
        unitCooldown = GetComponent<UnitCooldown>();
        enemyWave = GetComponent<EnemyWave>();
    }

    private void Update()
    {
        gameManager.WheatBar.fillAmount = wheatProduce.WheatBarPercent();
        gameManager.ConsumeBar.fillAmount = wheatProduce.ConsumeBarPercent();

        gameManager.WorkerBar.fillAmount = unitCooldown.WorkerBarPercent();
        gameManager.WarriorBar.fillAmount = unitCooldown.WarriorBarPercent();

        gameManager.EnemyWaveBar.fillAmount = enemyWave.EnemyWaveBarPercent();
    }
}
