using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float deathDuration;
    [SerializeField] private Animator imageAnimator;
    [SerializeField] private GameObject player;
    [SerializeField] private AnimationPlayer playerAnimation;

    private bool menuPressed;

    public void StartDeath() => StartCoroutine(Death());

    private IEnumerator Death()
    {
        //playerAnimation.DeathAnimation();
        yield return new WaitForSeconds(deathDuration);
        Destroy(player);
        imageAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLoadLevel(int index, float delay) => StartCoroutine(LoadLevel(index, delay));

    private IEnumerator LoadLevel(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        imageAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(index);
    }

    public void ReturnToMenu()
    {
        if (!menuPressed)
        {
            menuPressed = true;
            StartCoroutine(LoadLevel(0, 0));
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            AudioSource music = GameObject.Find("Music Source").GetComponent<AudioSource>();
            float temp = PlayerPrefs.GetFloat("music");
            music.time = temp;
        }
    }
}
