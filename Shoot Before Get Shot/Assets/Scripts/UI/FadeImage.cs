using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] 
    private ButtonManager buttonManager;

    [SerializeField] 
    private float fadeInDuration;

    private Animator animator;
    private HealthPlayer player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player")?.GetComponent<HealthPlayer>();
    }

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
        if (player != null) player.onDeath += Death;
    }

    private void OnDisable()
    {
        buttonManager.onFadeIn -= FadeIn;
        if (player != null) player.onDeath -= Death;
    }
}
