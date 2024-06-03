using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private float animationDuration;
    [SerializeField] private LevelManager levelManager;

    private Animator animator;
    private bool opened;

    private void Awake() => animator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !opened)
        {
            opened = true;
            StopAllCoroutines();
            StartCoroutine(OpenDoor());
        }

        if (gameObject.name == "Final Door")
        {
            levelManager.StartLoadLevel(2, 0);

            AudioSource music = GameObject.Find("Music Source").GetComponent<AudioSource>();
            PlayerPrefs.SetFloat("music", music.time);
        }
    }

    private IEnumerator OpenDoor()
    {
        animator.SetTrigger("isOpen");
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }
}
