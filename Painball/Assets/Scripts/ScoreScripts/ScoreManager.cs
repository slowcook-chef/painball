using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // instance
    public int score = 0;  // Player's current score
    public Text scoreText; // UI Text to display the score

    // Ensure that only one instance of ScoreManager exists
    void Awake()
    {
        if (instance == null)
        {
            instance = this;  // Set the one true and holy instance
        }
        else
        {
            Destroy(gameObject);  // Protects our holy singleton existence 
        }
    }

    // Method to increase the score and update the UI
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // Update the UI text element with the current score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}