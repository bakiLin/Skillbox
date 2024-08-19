using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer mixer;

    [SerializeField] 
    private Slider sliderMusic, sliderSFX;

    [SerializeField]
    private int minSoundValue;

    [Inject] 
    private Shading fadeImage;

    private void Start()
    {
        SetSliderValue(sliderMusic, "music volume");
        SetSliderValue(sliderSFX, "sfx volume");
    }

    private void SetSliderValue(Slider slider, String parameter)
    {
        mixer.GetFloat(parameter, out float volume);
        slider.value = volume;
        ChangeVolume(parameter, volume);
    }

    public void FadeIn(int sceneIndex) => fadeImage.FadeIn(sceneIndex, 2f);

    public void QuitGame() => Application.Quit();

    public void MusicVolume(float volume) => ChangeVolume("music volume", volume);

    public void SFXVolume(float volume) => ChangeVolume("sfx volume", volume);

    private void ChangeVolume(string parameter, float volume)
    {
        if (volume == minSoundValue) mixer.SetFloat(parameter, -80);
        else mixer.SetFloat(parameter, volume);
    }
}
