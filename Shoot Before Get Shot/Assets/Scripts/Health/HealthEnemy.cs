using UnityEngine;

public class HealthEnemy : Health
{
    [SerializeField]
    private Transform fill;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (healthCurrent <= 0f) Destroy(fill.parent.gameObject);
    }

    protected override void SetHealth()
    {
        Vector3 fillScale = fill.localScale;
        fillScale.x = healthCurrent / healthMax;
        fill.localScale = fillScale;
    }
}
