using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public GameManager gameManager;
    public int score = 0;  // Player's current score
    public int highscoreSmall=6660;
    public int highscoreMedium = 66600;
    public int highscoreBig=666000;
    public TMP_Text scoreText; // TMPro component to display the score
    public TMP_Text highscoreText;

    // Ensure that only one instance of ScoreManager exists
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if(gameManager==null){
            print("Game manager null, you might be in trouble");
        }
    }

    // Method to reset the score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText(); // Call to update the displayed score
    }

    // Method to increase the score and update the UI
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText(); // Call to update the displayed score
        //print("Score increased: " + score); // Print to console
    }

    // Update the UI text element with the current score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Update UI
        }
        //print("Score updated in UI: " + score); // Print to console
        CompareHighscore();
    }

    public void CompareHighscore(){
        if(score > highscoreBig){
            // WIN
            gameManager.Win();
        }
        else if(score > highscoreMedium){
            //Level
        }
        else if(score > highscoreSmall){
            // Game manager unlock evil board
            gameManager.EasyLevelBeaten();
        }
        //do nothing
    }
}
