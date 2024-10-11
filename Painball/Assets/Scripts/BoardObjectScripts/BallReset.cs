using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Make sure to check the "Is Trigger" box
[RequireComponent(typeof(Collider2D))]
public class BallReset : MonoBehaviour
{

    public Transform resetPosition; // Set this to where you want the ball to respawn

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Make sure the ball has the "Ball" tag
        {
            other.transform.position = resetPosition.position; // Move the ball to the spawn position
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Reset the velocity
        }
    }


    
}

