using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private float buttonSfxOffset;
    [SerializeField] private Animator shadeImage;

    private void Start() => sfxSource.time = buttonSfxOffset;

    public void StartGame() => StartCoroutine(LoadStartLevel());

    private IEnumerator LoadStartLevel()
    {
        sfxSource.Play();
        shadeImage.gameObject.SetActive(true);
        shadeImage.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        sfxSource.Play();
        Application.Quit();
    }

    public void ButtonClick() => sfxSource.Play();

    public void SetMusicVolume(float volume) => mixer.SetFloat("music volume", volume);

    public void SetSFXVolume(float volume) => mixer.SetFloat("sfx volume", volume);

    public void StopTime() => Time.timeScale = 0f;

    public void TimeContinue() => Time.timeScale = 1f;
}
