using UnityEngine;

public class MovementPlayer : Movement
{
    private new PlayerAnimation animation;

    protected override void Awake()
    {
        base.Awake();
        animation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();

        Rotate(moveDirection.x, 0f);
        animation.Run(moveDirection);
    }
}
