using System.Collections;
using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    [SerializeField] 
    protected GameObject bullet;

    [SerializeField] 
    protected float shootDelay;

    protected Health health;

    protected virtual void Awake() => health = GetComponent<Health>();

    protected virtual void Start() => StartShooting();

    protected abstract IEnumerator ShootCoroutine();

    public virtual void StartShooting() => StartCoroutine(ShootCoroutine());

    public virtual void StopShooting() => StopAllCoroutines();

    protected virtual void OnEnable() => health.onDeath += StopShooting;

    protected virtual void OnDisable() => health.onDeath -= StopShooting;
}
