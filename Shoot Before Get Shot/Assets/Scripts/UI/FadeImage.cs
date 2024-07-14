using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    [SerializeField] 
    private ButtonManager buttonManager;

    private Animator animator;
    private HealthPlayer player;
    private Challenge challenge;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player")?.GetComponent<HealthPlayer>();
        challenge = FindObjectOfType<Challenge>();
    }

    private void FadeIn(int index, int time) => StartCoroutine(FadeInCoroutine(index, time));

    private IEnumerator FadeInCoroutine(int index, int time)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }

    private void Death() => StartCoroutine(DeathCoroutine());

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        buttonManager.onFadeIn += FadeIn;
        if (player != null) player.onDeath += Death;
        if (challenge != null) challenge.onWin += FadeIn;
    }

    private void OnDisable()
    {
        buttonManager.onFadeIn -= FadeIn;
        if (player != null) player.onDeath -= Death;
        if (challenge != null) challenge.onWin += FadeIn;
    }
}
