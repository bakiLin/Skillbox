using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] 
    protected float healthMax, healthCurrent;

    protected virtual void Start() => SetHealth();

    protected abstract void SetHealth();

    public virtual void TakeDamage(int damage)
    {
        if (healthCurrent > 0f)
        {
            healthCurrent -= damage;
            SetHealth();
        }
    }
}
