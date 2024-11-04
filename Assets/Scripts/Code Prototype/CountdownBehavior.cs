using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownBehavior : MonoBehaviour
{
    public float CountdownTimer = 60f; // Initial countdown timer value
    public Text timerText; // Reference to the UI text component for displaying the timer
    private bool isCountingDown = false; // Flag to check if the countdown is active
    public ScoreAdder scoreAdder; // Reference to ScoreAdder
    public ScoreDisplay scoreDisplay; // Reference to ScoreDisplay
    public HighScoreDisplay highScoreDisplay; // Reference to HighScoreDisplay

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer text with the initial countdown value
        timerText.text = "Time: " + Mathf.Ceil(CountdownTimer).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the countdown is active and the timer is greater than 0
        if (isCountingDown && CountdownTimer > 0)
        {
            // Decrease the timer by the time elapsed since the last frame
            CountdownTimer -= Time.deltaTime;
            if (CountdownTimer <= 0)
            {
                // Ensure the timer does not go below 0
                CountdownTimer = 0;
                scoreAdder.ClearPan(); // Clear the pan when the timer reaches zero
                CheckAndSetHighScore(); // Check and set the high score before resetting the score
                ResetScore(); // Reset the score when the timer reaches zero
            }

            // Update the timer text with the current countdown value
            timerText.text = "Time: " + Mathf.Ceil(CountdownTimer).ToString();
        }
    }

    // Method to start the countdown
    public void StartCountdown()
    {
        isCountingDown = true;
    }

    // Method to check and set the high score
    void CheckAndSetHighScore()
    {
        if (scoreDisplay.score > highScoreDisplay.highScore)
        {
            highScoreDisplay.highScore = scoreDisplay.score;
            highScoreDisplay.UpdateHighScoreText();
        }
    }

    // Method to reset the score
    void ResetScore()
    {
        scoreDisplay.score = 0;
        scoreDisplay.UpdateScoreText();
    }
}
