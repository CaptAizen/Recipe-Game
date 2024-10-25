using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public RecipePool pool;
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
            pool.SpawnRecipe();
        }
        if (clicks % 2 == 0)
        {
            pool.DestroyRecipe();
        }
        
    }
}
