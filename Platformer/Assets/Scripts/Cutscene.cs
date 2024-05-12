using System.Collections;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        playerJump.enabled = false;
        playerMovement.enabled = false;

        StartCoroutine(TurnOnMovement());
    }

    private IEnumerator TurnOnMovement()
    {
        yield return new WaitForSeconds(3);

        playerJump.enabled = true;
        playerMovement.enabled = true;

        Destroy(this);
    }
}
