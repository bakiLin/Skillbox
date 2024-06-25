using System.Collections;
using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    [SerializeField] 
    protected GameObject bullet;

    [SerializeField] 
    protected float shootDelay;

    protected AnimationParent characterAnimation;

    protected virtual void Awake() => characterAnimation = GetComponent<AnimationParent>();

    protected virtual void Start() => StartCoroutine(ShootCoroutine());

    protected abstract IEnumerator ShootCoroutine();
}
