using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ball;
    public float launchForce = 1000f;
    public KeyCode launchKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(launchKey))
        {
            ball.AddForce(Vector3.forward * launchForce);
        }
    }
}

