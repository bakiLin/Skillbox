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
    private ResourceManager resourceManager;

    private Animator animator; 

    private void Awake() => animator = GetComponent<Animator>();

    public void Open()
    {
        animator.SetTrigger("open");

        if (doorType == DoorType.Finish)
        {
            fadeImage.FadeIn(SceneManager.GetActiveScene().buildIndex + 1, 2f);
            resourceManager.Save();
        }
    }

    public void DeleteSelf() => Destroy(gameObject);  // Used in "Open" animation
}
