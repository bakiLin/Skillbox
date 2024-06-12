using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float fadeInDuration;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void FadeIn(int index) => StartCoroutine(FadeInCoroutine(index));

    private IEnumerator FadeInCoroutine(int index)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(index);
    }

    private void OnEnable()
    {
        buttonManager.onGameStart += FadeIn;
        buttonManager.onReturnToMenu += FadeIn;
    }

    private void OnDisable()
    {
        buttonManager.onGameStart -= FadeIn;
        buttonManager.onReturnToMenu -= FadeIn;
    }
}
