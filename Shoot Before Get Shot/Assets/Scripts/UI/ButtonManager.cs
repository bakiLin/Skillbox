using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sliderMusic, sliderSFX;

    public Action<int> onGameStart, onReturnToMenu;

    private void Start()
    {
        SetSliderValue(sliderMusic, "music volume");
        SetSliderValue(sliderSFX, "sfx volume");
    }

    private void SetSliderValue(Slider slider, String parameter)
    {
        mixer.GetFloat(parameter, out float volume);
        slider.value = volume;
    }

    public void StartGame() => onGameStart?.Invoke(1);

    public void QuitGame() => Application.Quit();

    public void MusicVolume(float volume) => ChangeVolume("music volume", volume);

    public void SFXVolume(float volume) => ChangeVolume("sfx volume", volume);

    private void ChangeVolume(string parameter, float volume)
    {
        if (volume == -25) mixer.SetFloat(parameter, -80);
        else mixer.SetFloat(parameter, volume);
    }

    public void ReturnToMenu() => onReturnToMenu?.Invoke(0);
}
