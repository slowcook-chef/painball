using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ball"))  // Check if the colliding object is the ball
        {
            ScoreManager.instance.AddScore(scoreValue);  // Add score
            //Debug.Log("Ball hit scoring object. Score added: " + scoreValue); // Debug log

            // Play hit sound if it's set
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
                //Debug.Log("Hit sound played.");
            }
        }
    }

}
