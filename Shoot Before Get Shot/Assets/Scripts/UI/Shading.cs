using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Shading : MonoBehaviour
{
    [Inject]
    private ResourceManager resourceManager;

    protected Animator animator;

    protected virtual void Awake() => animator = GetComponent<Animator>();

    public void FadeIn(int sceneIndex, float time) => StartCoroutine(FadeInCoroutine(sceneIndex, time));

    private IEnumerator FadeInCoroutine(int sceneIndex, float time)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(time);

        resourceManager.Save();

        SceneManager.LoadScene(sceneIndex);
    }
}
