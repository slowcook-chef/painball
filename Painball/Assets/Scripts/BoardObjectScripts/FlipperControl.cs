using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode key = KeyCode.Z; // Default key is Z for the left flipper
    public float force = 500f;
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        JointMotor motor = hinge.motor;

        if (Input.GetKey(key))
        {
            motor.targetVelocity = force; // Move the flipper when key is pressed
        }
        else
        {
            motor.targetVelocity = -force; // Move back to the resting position
        }

        hinge.motor = motor;
    }
}

