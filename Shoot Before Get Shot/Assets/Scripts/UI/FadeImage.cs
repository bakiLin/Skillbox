using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float fadeInDuration;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void StartFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(1);
    }

    private void OnEnable() => buttonManager.playPressedEvent += StartFadeIn;

    private void OnDisable() => buttonManager.playPressedEvent -= StartFadeIn;
}
