using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public CountdownBehavior countdownTimer;
    public bool gameOn = false;

    private void OnMouseDown()
    {
        countdownTimer.StartCountdown();
        gameOn = true;
        if (countdownTimer.CountdownTimer == 0)
        {
            countdownTimer.CountdownTimer = 60;
            scoreDisplay.score = 0;
        }
    }
}
