using System.Collections;
using UnityEngine;

public class ExplosionButton : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine("Boom");
        }
    }

    private IEnumerator Boom()
    {
        bomb.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        bomb.SetActive(false);
        Destroy(this);
    }
}
