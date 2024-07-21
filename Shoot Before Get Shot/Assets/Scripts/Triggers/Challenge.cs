using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Challenge : MonoBehaviour
{
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [Space]
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [Space]
    [SerializeField] private float itemSpawnTime;
    [SerializeField] private float enemySpawnTime;
    [Space]

    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField]
    private GameObject wall;

    [SerializeField]
    private GameObject[] items, enemies;

    [SerializeField]
    private HealthPlayer player;

    private Random rand;
    private bool challengeOn;
    private float time = 30f, itemTime = 1f, enemyTime = 2f;

    public Action<int, int> onWin;

    private void Start() => rand = new Random();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            challengeOn = true;
            timer.enabled = true;
            wall.SetActive(true);
        }
    }

    private void Update()
    {
        if (challengeOn)
        {
            if (time > 0f)
            {
                time -= Time.deltaTime;
                int num = (int)Mathf.Round(time); ;
                timer.text = "time left: " + num.ToString();

                Spawn(ref itemTime, itemSpawnTime, items);
                Spawn(ref enemyTime, enemySpawnTime, enemies);
            }
            else
            {
                onWin?.Invoke(0, 3);
                timer.text = "time over";
                wall.SetActive(false);
                this.enabled = false;
            }
        }
    }

    private void Spawn(ref float spawnTime, float spawnCooldown, GameObject[] arr)
    {
        if (spawnTime > 0f)
            spawnTime -= Time.deltaTime;
        else
        {
            spawnTime = spawnCooldown;

            double x = rand.NextDouble() * (Mathf.Abs(xMax) - Mathf.Abs(xMin));
            double y = rand.NextDouble() * (Mathf.Abs(yMax) - Mathf.Abs(yMin));

            float positionX = xMin + Mathf.Abs((float)x);
            float positionY = yMin + Mathf.Abs((float)y);

            Vector2 spawnPosition = new Vector2(positionX, positionY);

            int index = rand.Next(0, 100);
            index = index > 70 ? 1 : 0;
            Instantiate(arr[index], spawnPosition, Quaternion.identity);
        }
    }

    private void Death()
    {
        challengeOn = false;
        this.enabled = false;
    }

    private void OnEnable() => player.onDeath += Death;

    private void OnDisable() => player.onDeath -= Death;
}
