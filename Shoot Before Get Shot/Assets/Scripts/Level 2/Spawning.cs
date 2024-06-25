using System.Collections;
using UnityEngine;
using Random = System.Random;

public class Spawning : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] items;
    [SerializeField] private int[] constraint;
    [SerializeField] private float spawnDelay;

    [HideInInspector] public Transform player;

    private Random random = new Random();

    private void Awake() => player = FindObjectOfType<MovementPlayer>().transform;

    public void StartSpawn()
    {
        StopAllCoroutines();
        StartCoroutine(Spawn(enemies));
        StartCoroutine(Spawn(items));
    }

    private IEnumerator Spawn(GameObject[] spawnObj)
    {
        while (true)
        {
            if (player != null)
            {
                Vector2 spawnPosition = GetRandomPosition();
                GameObject obj = spawnObj[random.Next(0, 2)];
                Instantiate(obj, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return null;
        }
    }

    private Vector2 GetRandomPosition()
    {
        float posX = random.Next(constraint[0], constraint[1]);
        float posY = random.Next(constraint[2], constraint[3]);

        return new Vector2 (posX, posY);
    }
}
