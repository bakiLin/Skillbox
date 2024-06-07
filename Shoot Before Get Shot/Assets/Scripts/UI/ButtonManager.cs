using UnityEngine;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public delegate void PlayPressedDelegate();
    public event PlayPressedDelegate playPressedEvent;

    private bool buttonPressed;

    public void StartGame()
    {
        if (!buttonPressed) 
        {
            playPressedEvent?.Invoke();
            buttonPressed = true;
        }
    }

    public void QuitGame() => Application.Quit();

    public void MusicVolume(float volume) => AudioVolume("music volume", volume);

    public void SFXVolume(float volume) => AudioVolume("sfx volume", volume);

    private void AudioVolume(string parameter, float volume)
    {
        if (volume == -25) mixer.SetFloat(parameter, -80);
        else mixer.SetFloat(parameter, volume);
    }
}
