using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Transform carTransform;
    private Vector3 lastCarPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
            carTransform = collision.transform;

        if (collision.gameObject.tag == "Platform")
        {
            carTransform = null;
            lastCarPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (carTransform != null)
        {
            if (lastCarPosition == Vector3.zero)
                lastCarPosition = carTransform.position;
            else
            {
                transform.position += carTransform.position - lastCarPosition;
                lastCarPosition = carTransform.position;
            }
        }
    }
}
