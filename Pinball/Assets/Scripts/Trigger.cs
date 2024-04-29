using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Handle;
    public float zPosition;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = Handle.transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Handle.transform.localPosition = new Vector3(startPosition.x, startPosition.y, zPosition);
        }
    }
}
