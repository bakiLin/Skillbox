using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float detectionDistance, stopDistance, speed, topPosition, bottomPosition;
    [SerializeField] private EmemyType enemyType;

    private EnemyShoot enemyShoot;
    private Transform player;
    private EnemyAnimation enemyAnimation;
    private Rigidbody2D rb;
    private Vector3 direction;
    private enum EmemyType
    {
        Distant,
        Melee
    }

    private void Awake()
    {
        enemyShoot = GetComponent<EnemyShoot>();
        player = FindObjectOfType<PlayerMovement>().transform;
        enemyAnimation = GetComponent<EnemyAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            float currentDistance = Vector2.Distance(transform.position, player.position);
            bool isRunning = false;

            if (currentDistance < detectionDistance)
            {
                Rotate();

                direction.y = DirectionValue(player.position.y, transform.position.y, topPosition, bottomPosition);
                direction.x = DirectionValue(player.position.x, transform.position.x, stopDistance, -stopDistance);

                if (direction == Vector3.zero && enemyType == EmemyType.Melee) enemyShoot.Shoot();
                isRunning = MovementState(currentDistance);
            }
            else
                direction = Vector3.zero;

            enemyAnimation.RunAnimation(isRunning);
        }
        else
            enemyAnimation.RunAnimation(false);
    }

    private void FixedUpdate() => rb.MovePosition(transform.position + Time.fixedDeltaTime * speed * direction);

    private void Rotate()
    {
        float rotationY = player.position.x < transform.position.x ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    private float DirectionValue(float playerAxis, float enemyAxis, float distance_1, float distance_2)
    {
        if (playerAxis - enemyAxis > distance_1) return 1f;
        if (playerAxis - enemyAxis < distance_2) return -1f;
        if (playerAxis == player.position.y && enemyType == EmemyType.Distant) enemyShoot.Shoot();
        return 0f;
    }

    private bool MovementState(float distance)
    {
        if (distance > stopDistance) return true;
        if (Mathf.Abs(transform.position.y - player.position.y) > topPosition) return true;
        return false;
    }
}
