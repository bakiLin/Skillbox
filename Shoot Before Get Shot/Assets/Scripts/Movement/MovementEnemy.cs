using UnityEngine;

public class MovementEnemy : Movement
{
    private enum EnemyType
    {
        Range,
        Melee
    }

    [SerializeField]
    private Vector2 detectDistance, attackDistance, fleeDistance;

    [SerializeField]
    private EnemyType enemyType;

    private Transform player;
    private ShootEnemy shootScript;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<MovementPlayer>().transform;
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

                if (enemyType == EnemyType.Range && moveDirection.y == 0f ||        //������� ����� �������, ����� � ����� Y ���������� � �������
                    enemyType == EnemyType.Melee && moveDirection == Vector3.zero)  //������� ����� ������� ������ ������ �� ������
                {
                    shootScript.Shoot();
                }
            }
            else 
                moveDirection = Vector3.zero;

            characterAnimation.Run(moveDirection);
        }
    }

    private float GetDirection(float currentDistance, float attackDistance, float fleeDistance)
    {
        float distance = Mathf.Abs(currentDistance);
        if (distance < fleeDistance) return currentDistance < 0f ? 1f : -1f;
        if (distance < attackDistance) return 0f;
        return currentDistance > 0f ? 1f : -1f;
    }
}