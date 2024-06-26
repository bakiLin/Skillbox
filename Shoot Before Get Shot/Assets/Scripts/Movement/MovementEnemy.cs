using UnityEngine;

public class MovementEnemy : Movement
{
    [SerializeField]
    private Vector2 detectDistance, attackDistance, fleeDistance;

    private Transform player;
    private ShootEnemy shootScript;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<MovementPlayer>().transform;
        shootScript = GetComponent<ShootEnemy>();
    }

    //—оздать enum с типом врага и настроить услови€ дл€ атаки

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

                if (moveDirection.y == 0f) shootScript.Shoot();
            }
            else moveDirection = Vector3.zero;

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