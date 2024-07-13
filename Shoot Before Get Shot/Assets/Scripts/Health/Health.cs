using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] 
    protected float healthMax, healthCurrent;

    public Action onDeath;

    protected virtual void Start() => SetHealth();

    protected abstract void SetHealth();

    public virtual void TakeDamage(float damage)
    {
        if (healthCurrent > 0f)
        {
            healthCurrent -= damage;
            SetHealth();
        }
        
        if (healthCurrent <= 0f)
        {
            onDeath?.Invoke();
            Destroy(this);
        }
    }
}
