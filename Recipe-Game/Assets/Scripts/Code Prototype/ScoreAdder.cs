using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public CountdownBehavior countdownTimer;
    public ScoreDisplay scoreDisplay;
    public float clicks = 0;

    void OnMouseDown()
    {
        clicks += 1;

        if (clicks >= 2 && countdownTimer.CountdownTimer > 0)
        {
            scoreDisplay.score += 1;
            scoreDisplay.UpdateScoreText();
        }
        
    }
}
