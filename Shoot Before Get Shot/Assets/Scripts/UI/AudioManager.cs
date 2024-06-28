using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField, Range(0, 1)] 
    private float clickSoundOffset;

    private AudioSource audioSource;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    public void ClickSFX()
    {
        audioSource.time = audioSource.clip.length * clickSoundOffset;
        audioSource.Play();
    }
}
