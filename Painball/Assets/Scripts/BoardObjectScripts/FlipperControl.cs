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

        
        if (Input.GetKey(key))
        {
            motor.motorSpeed = force; // Move the flipper when key is pressed
        }
        else if (hinge.angle > 0) // Adjust this condition based on your flipper's design
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
