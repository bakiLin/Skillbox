using UnityEngine;

public class MovementEnemy : Movement
{
    private enum EnemyType
    {
        Range,
        Melee
    }

    //stop from pushing player

    [SerializeField]
    private Vector2 detectDistance, attackDistance, fleeDistance;

    [SerializeField]
    private EnemyType enemyType;

    private Transform player;
    private ShootEnemy shootScript;

    protected override void Awake()
    {
        base.Awake();
        MovementPlayer temp = FindObjectOfType<MovementPlayer>();
        player = temp?.transform;
        shootScript = GetComponent<ShootEnemy>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 currentDistance = player.position - transform.position;

            if (Mathf.Abs(currentDistance.x) < detectDistance.x &&
                Mathf.Abs(currentDistance.y) < detectDistance.y)
            {
                moveDirection.x = GetDirection(currentDistance.x, attackDistance.x, fleeDistance.x);
                moveDirection.y = GetDirection(currentDistance.y, attackDistance.y, fleeDistance.y);

                Rotate(player.position.x, transform.position.x);

                if (enemyType == EnemyType.Range && moveDirection.y == 0f ||        //дальние враги атакуют, когда в одной Y координате с игроком
                    enemyType == EnemyType.Melee && moveDirection == Vector3.zero)  //ближние враги акатуют только вблизи от игрока
                {
                    shootScript.Shoot();
                }
            }
            else moveDirection = Vector3.zero;

            characterAnimation.Run(moveDirection);
        }
        else moveDirection = Vector3.zero;
    }

    private float GetDirection(float currentDistance, float attackDistance, float fleeDistance)
    {
        float distance = Mathf.Abs(currentDistance);
        if (distance < fleeDistance) return currentDistance < 0f ? 1f : -1f;
        if (distance < attackDistance) return 0f;
        return currentDistance > 0f ? 1f : -1f;
    }
}