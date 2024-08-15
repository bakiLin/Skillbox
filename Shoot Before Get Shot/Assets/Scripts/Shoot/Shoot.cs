using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    [SerializeField] 
    protected GameObject bullet;

    [SerializeField] 
    protected float shootDelay;

    protected AnimManager anim;
    protected Health health;
    protected float cooldown;

    protected virtual void Awake()
    {
        anim = GetComponent<AnimManager>();
        health = GetComponent<Health>();
    }

    protected virtual void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
            ShootAction();
    }

    protected abstract void ShootAction();

    protected virtual void OnEnable()
    {
        health.onDeath += () => Destroy(this); 
    }

    private void OnDisable()
    {
        health.onDeath -= () => Destroy(this);
    }
}
