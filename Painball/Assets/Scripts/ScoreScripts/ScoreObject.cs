using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreObject : MonoBehaviour
{
    public int scoreValue = 100;  // Customizable score value for each object
    public AudioClip hitSound;    // Customizable hit sound for each object. May need to be changed for our audio pipeleine. 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource for playing sound
    }

    // Triggered when the ball collides with this object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")  // Check if the colliding object is the ball
        {
            ScoreManager.instance.AddScore(scoreValue);  // Add score based on the object's score value

            // Play hit sound (if set)
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);  // Play the sound when hit
            }

            // Optionally, add other effects like flashing lights, particle effects, etc.
        }
    }
}