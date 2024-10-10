using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ScoringObject : MonoBehaviour
{
    public int scoreValue = 100;  // Score awarded when hit
    public AudioClip hitSound;     // Sound effect for when the object is hit
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Use OnTriggerEnter2D for 2D collision detection
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ball"))  // Check if the colliding object is the ball
        {
            ScoreManager.instance.AddScore(scoreValue);  // Add score

            // Play hit sound if it's set
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }


        }
    }
}
