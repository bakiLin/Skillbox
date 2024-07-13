using UnityEngine;

public class Door : MonoBehaviour
{
    private enum DoorType
    {
        Regular,
        Finish
    }

    [SerializeField]
    private DoorType doorType;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    public void Open()
    {
        animator.SetTrigger("open");
    }

    private void DeleteSelf() => Destroy(gameObject);
}
