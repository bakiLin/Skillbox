using UnityEngine;

public class HealthEnemy : Health
{
    [SerializeField]
    private Transform fill;

    protected override void SetHealth()
    {
        Vector3 fillScale = fill.localScale;
        fillScale.x = healthCurrent / healthMax;
        fill.localScale = fillScale;
    }
}
