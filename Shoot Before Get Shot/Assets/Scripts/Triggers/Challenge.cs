using TMPro;
using UnityEngine;
using Random = System.Random;

public class Challenge : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField]
    private GameObject wall;

    [Space]
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [Space]
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;

    private Random rand;
    private bool challengeOn;
    private float time = 30f;
    private float itemSpawnTime, enemySpawnTime;

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

                Spawn(ref itemSpawnTime);
            }
            else
            {
                this.enabled = false;
                timer.text = "time over";
            }
        }
    }

    private void Spawn(ref float spawnTime)
    {
        if (spawnTime > 0f)
            spawnTime -= Time.deltaTime;
        else
        {
            spawnTime = 3f;

            float x = (float)(rand.NextDouble() * (Mathf.Abs(xMax) - Mathf.Abs(xMin)));
            float y = (float)(rand.NextDouble() * (Mathf.Abs(yMax) - Mathf.Abs(yMin)));

            Vector2 spawnPosition = new Vector2(xMin + Mathf.Abs(x), yMin + Mathf.Abs(y));
        }
    }
}
