using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public Transform spawnTransform; // Set this to where you want the ball to respawn

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Make sure the ball has the "Ball" tag
        {
            other.transform.position = spawnTransform.position; // Move the ball to the spawn position
            other.GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset the velocity
        }
    }
}

