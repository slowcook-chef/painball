using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode key = KeyCode.Z; // Default key is Z for the left flipper
    public float force = 500f;
    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;

        // Check if the flipper is in the resting position
        if (Input.GetKey(key))
        {
            motor.motorSpeed = force; // Move the flipper when key is pressed
        }
        else if (transform.rotation.eulerAngles.z > 0) // Check the angle using the transform's rotation
        {
            motor.motorSpeed = -force; // Move back to the resting position
        }
        else
        {
            motor.motorSpeed = 0; // Stop the motor when in resting position
        }

        hinge.motor = motor;
    }
}
