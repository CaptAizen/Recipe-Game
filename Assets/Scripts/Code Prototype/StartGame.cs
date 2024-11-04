using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // References to other scripts
    public ScoreAdder scoreAdder;
    public ScoreDisplay scoreDisplay;
    public CountdownBehavior countdownTimer;
    // Boolean to check if the game is on
    public bool gameOn = false;

    // Method called when the game object is clicked
    private void OnMouseDown()
    {
        // Start the countdown timer
        countdownTimer.StartCountdown();
        gameOn = true;
        // Reset the game state if the countdown timer is zero
        if (countdownTimer.CountdownTimer == 0)
        {
            countdownTimer.CountdownTimer = 60;
            scoreDisplay.score = 0;
            scoreAdder.clicks = 0;
            scoreDisplay.UpdateScoreText();
        }
    }
}
