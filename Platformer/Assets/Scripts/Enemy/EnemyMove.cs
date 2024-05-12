using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Vector2 moveToPosition;
    [SerializeField] private float speed;

    private Vector2 startPosition;
    private bool atStartPosition = true;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            if (atStartPosition)
                transform.position = Vector2.MoveTowards(transform.position, moveToPosition, speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            if (moveToPosition.x >= transform.position.x)
            {
                atStartPosition = false;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            if (startPosition.x <= transform.position.x)
            {
                atStartPosition = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            yield return null;
        }
    }
}
