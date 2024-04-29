using UnityEngine;
using Random = System.Random;

public class ChangeDir : MonoBehaviour
{
    public int[] DirectionChangeTime;
    public float RotationSpeed;

    private Random rand = new Random();
    private JointMotor joint;
    private float t;

    void Start()
    {
        joint = GetComponent<HingeJoint>().motor;
        joint.targetVelocity = RotationSpeed;

        int chance = rand.Next(0, 2);

        if (chance == 1)
            joint.targetVelocity *= -1;

        GetComponent<HingeJoint>().motor = joint;

        t = rand.Next(DirectionChangeTime[0], DirectionChangeTime[1]);
    }

    void Update()
    {
        t -= Time.deltaTime;

        if (t < 0)
        {
            t = rand.Next(DirectionChangeTime[0], DirectionChangeTime[1]);

            int chance = rand.Next(0, 2);

            if (chance == 1)
            {
                joint.targetVelocity *= -1;
                GetComponent<HingeJoint>().motor = joint;
            }
        }
    }
}
