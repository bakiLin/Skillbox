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

    [Inject]
    private Shading fadeImage;

    [Inject] 
    private HealthPlayer healthPlayer;  //реализовать перенос здоровья на новый уровень

    private Animator animator; 

    private void Awake() => animator = GetComponent<Animator>();

    public void Open()
    {
        animator.SetTrigger("open");

        if (doorType == DoorType.Finish)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            fadeImage.FadeIn(sceneIndex, 2f);
        }    
    }

    public void DeleteSelf() => Destroy(gameObject);
}
