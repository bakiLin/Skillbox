using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private float clickSoundOffset;

    private AudioSource audioSource;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    public void ClickSFX()
    {
        audioSource.time = audioSource.clip.length * clickSoundOffset;
        audioSource.Play();
    }
}
