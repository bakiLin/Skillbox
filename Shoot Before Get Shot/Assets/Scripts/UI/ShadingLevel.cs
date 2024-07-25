using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ShadingLevel : Shading
{
    [Inject]
    private HealthPlayer healthPlayer;

    private void Death() => StartCoroutine(DeathCoroutine());

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable() => healthPlayer.onDeath += Death;

    private void OnDisable() => healthPlayer.onDeath -= Death;
}
