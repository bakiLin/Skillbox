using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start() => Destroy(gameObject, 2f);

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.right, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")) 
            Destroy(gameObject);
    }
}
