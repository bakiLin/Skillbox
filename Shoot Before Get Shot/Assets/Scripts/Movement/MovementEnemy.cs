using UnityEngine;

public class MovementEnemy : Movement
{
    [SerializeField]
    private Vector2 detectDistance, attackDistance;

    private Transform player;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<MovementPlayer>().transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 currentDistance = player.position - transform.position;

            if (Mathf.Abs(currentDistance.x) < detectDistance.x)
            {
                Rotate(player.position.x, transform.position.x);

                if (currentDistance.x > 0f) moveDirection.x = 1f;
                else moveDirection.x = -1f;

                if (Mathf.Abs(currentDistance.x) < attackDistance.x) 
                    moveDirection.x = 0f;

                //if (currentDistance.x < 0.6f) moveDirection.x = -1f;
                //if (currentDistance.x > -0.6f) moveDirection.x = 1f;

                //if (currentDistance.x - attackDistance.x < 0.1f)
                //    moveDirection.x = 1f;

                //if (Mathf.Abs(currentDistance.y) < detectDistance.y)
                //{
                //    if (currentDistance.y > 0f) moveDirection.y = 1f;
                //    else moveDirection.y = -1f;

                //    if (Mathf.Abs(currentDistance.y) < attackDistance.y) 
                //        moveDirection.y = 0f;
                //}
            }
        }
    }

    //[SerializeField] float detectionDistance, stopDistance, speed, topPosition, bottomPosition;
    //[SerializeField] private EmemyType enemyType;

    //private EnemyShoot enemyShoot;
    //private Transform player;
    //private EnemyAnimation enemyAnimation;
    //private Rigidbody2D rb;
    //private Vector3 direction;
    //private enum EmemyType
    //{
    //    Distant,
    //    Melee
    //}

    //private void Awake()
    //{
    //    enemyShoot = GetComponent<EnemyShoot>();
    //    player = FindObjectOfType<PlayerMovement>().transform;
    //    enemyAnimation = GetComponent<EnemyAnimation>();
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    if (player != null)
    //    {
    //        float currentDistance = Vector2.Distance(transform.position, player.position);
    //        bool isRunning = false;

    //        if (currentDistance < detectionDistance)
    //        {
    //            Rotate();

    //            direction.y = DirectionValue(player.position.y, transform.position.y, topPosition, bottomPosition);
    //            direction.x = DirectionValue(player.position.x, transform.position.x, stopDistance, -stopDistance);

    //            if (direction == Vector3.zero && enemyType == EmemyType.Melee) enemyShoot.Shoot();
    //            isRunning = MovementState(currentDistance);
    //        }
    //        else
    //            direction = Vector3.zero;

    //        enemyAnimation.RunAnimation(isRunning);
    //    }
    //    else
    //        enemyAnimation.RunAnimation(false);
    //}

    //private void FixedUpdate() => rb.MovePosition(transform.position + Time.fixedDeltaTime * speed * direction);

    //private void Rotate()
    //{
    //    float rotationY = player.position.x < transform.position.x ? 180f : 0f;
    //    transform.rotation = Quaternion.Euler(0, rotationY, 0);
    //}

    //private float DirectionValue(float playerAxis, float enemyAxis, float distance_1, float distance_2)
    //{
    //    if (playerAxis - enemyAxis > distance_1) return 1f;
    //    if (playerAxis - enemyAxis < distance_2) return -1f;
    //    if (playerAxis == player.position.y && enemyType == EmemyType.Distant) enemyShoot.Shoot();
    //    return 0f;
    //}

    //private bool MovementState(float distance)
    //{
    //    if (distance > stopDistance) return true;
    //    if (Mathf.Abs(transform.position.y - player.position.y) > topPosition) return true;
    //    return false;
    //}
}
