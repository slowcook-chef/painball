using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public int score = 0;  // Player's current score
    public TMP_Text scoreText; // TMPro component to display the score

    // Ensure that only one instance of ScoreManager exists
    void Awake()
    {
        if (instance == null)
        {
            instance = this;  // Set the singleton instance
        }
        else
        {
            Destroy(gameObject);  // Protects the singleton existence 
        }
    }

    // Method to increase the score and update the UI
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText(); // Call to update the displayed score
        Debug.Log("Score increased: " + score); // Print to console
    }

    // Update the UI text element with the current score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update UI
        }
        Debug.Log("Score updated in UI: " + score); // Print to console
    }
}
