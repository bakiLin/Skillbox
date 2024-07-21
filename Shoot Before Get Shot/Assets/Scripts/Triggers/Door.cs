using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Door : MonoBehaviour
{
    private enum DoorType
    {
        Regular,
        Finish
    }

    [SerializeField]
    private DoorType doorType;

    public Action<int, int> onFinish;

    private Animator animator; 
    [Inject] private HealthPlayer healthPlayer;

    private void Awake() => animator = GetComponent<Animator>();

    public void Open()
    {
        animator.SetTrigger("open");

        if (doorType == DoorType.Regular)
        {
            print(healthPlayer.IsInjured());
        }

        if (doorType == DoorType.Finish)
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            onFinish?.Invoke(index, 2);
        }    
    }

    private void DeleteSelf() => Destroy(gameObject);
}
