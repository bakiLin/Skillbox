using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] 
    private ButtonManager buttonManager;

    [SerializeField]
    private HealthPlayer playerHealth;

    [SerializeField] 
    private float fadeInDuration;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void FadeIn(int index) => StartCoroutine(FadeInCoroutine(index));

    private IEnumerator FadeInCoroutine(int index)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(index);
    }

    private void Death() => StartCoroutine(DeathCoroutine());

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        buttonManager.onFadeIn += FadeIn;
        playerHealth.onDeath += Death;
    }

    private void OnDisable()
    {
        buttonManager.onFadeIn -= FadeIn;
        playerHealth.onDeath -= Death;
    }
}
