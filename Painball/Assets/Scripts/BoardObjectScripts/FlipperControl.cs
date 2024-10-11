using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode key; // Assign key in the Inspector for each flipper
    public float launchForce = 1000f; // Force for flipping
    public float restingAngle = 0f; // Resting position angle 
    public float maxFlipAngle = 45f; // Max flipping angle 
    public float motorTorque = 2000f; // Torque for motor

    private HingeJoint2D hinge;
    private JointMotor2D motor;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;  // Access motor settings
        motor.maxMotorTorque = motorTorque;  // Set the torque for the motor

        // Configure hinge limits for flipper movement
        JointAngleLimits2D limits = hinge.limits;
        limits.min = restingAngle;  // Minimum angle (resting position)
        limits.max = maxFlipAngle;  // Maximum angle (flipping position)
        hinge.limits = limits;
        hinge.useLimits = true;    // Use the limits to restrict movement

        // Enable the motor for the hinge joint
        hinge.useMotor = true;
    }

    void Update()
    {
        // Check if the assigned key is pressed
        if (Input.GetKey(key))
        {
            motor.motorSpeed = launchForce;  // Flip upwards
        }
        else
        {
            motor.motorSpeed = -launchForce * 0.5f;  // Return to resting position
        }

        hinge.motor = motor;  
    }
}
