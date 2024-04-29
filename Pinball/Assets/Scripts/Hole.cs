using UnityEngine;

public class Hole : MonoBehaviour
{
    public Vector3 ForceDirection;

    private Rigidbody rb;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Ball")
    //    {
    //        if (rb == null)
    //            rb = other.GetComponent<Rigidbody>();

    //        rb.AddForce(ForceDirection, ForceMode.Impulse);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (rb == null)
                rb = other.GetComponent<Rigidbody>();

            rb.AddForce(ForceDirection * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
