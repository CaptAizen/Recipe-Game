using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public StartGame game;
    public float clicks = 0;

    void OnMouseDown()
    {
        clicks += 1;

        if (clicks >= 2)
        {
            scoreDisplay.score += 1;
            scoreDisplay.UpdateScoreText();
        }
        
    }
}
