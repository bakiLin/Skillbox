using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float fadeInDuration;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void StartFadeIn(int index) => StartCoroutine(FadeIn(index));

    private IEnumerator FadeIn(int index)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(index);
    }

    private void OnEnable()
    {
        buttonManager.startGameAction += StartFadeIn;
        buttonManager.returnToMenuAction += StartFadeIn;
    }

    private void OnDisable()
    {
        buttonManager.startGameAction -= StartFadeIn;
        buttonManager.returnToMenuAction -= StartFadeIn;
    }
}
