using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode key = KeyCode.Z; // Default key is Z for the left flipper
    public float launchForce = 500f; // Force when flipping
    public float restingAngle = 0f; // The angle where the flipper rests
    public float maxFlipAngle = 45f; // Maximum angle the flipper can flip to

    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;
        float currentAngle = hinge.angle;

        if (Input.GetKey(key) && currentAngle < maxFlipAngle) // Only flip if under max angle
        {
            motor.motorSpeed = launchForce; // Flip when key is pressed
        }
        else if (currentAngle > restingAngle) // Move back to resting position
        {
            motor.motorSpeed = -launchForce; // Move back to the resting position
        }
        else
        {
            motor.motorSpeed = 0; // Stop the motor when at resting position
        }

        hinge.motor = motor;
    }
}
