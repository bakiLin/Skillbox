using System.Collections;
using UnityEngine;

public class ShootProgress : MonoBehaviour
{
    [SerializeField] private GameObject[] shootBarComponents;

    private float fillMaxScaleX;

    private void Start() => fillMaxScaleX = shootBarComponents[0].transform.localScale.x;

    public void ProgressFill(float shootDelay)
    {
        StopAllCoroutines();
        StartCoroutine(ProgressFillCoroutine(shootDelay));
    }

    private IEnumerator ProgressFillCoroutine(float shootDelay)
    {
        foreach (GameObject component in shootBarComponents)
            component.SetActive(true);

        float time = 0;

        while (time < shootDelay)
        {
            time += Time.deltaTime;

            Vector3 temp = shootBarComponents[0].transform.localScale;
            temp.x = fillMaxScaleX * time / shootDelay;
            shootBarComponents[0].transform.localScale = temp;

            yield return null;
        }

        foreach (GameObject component in shootBarComponents)
            component.SetActive(false);
    }
}
