using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public RecipePool pool;
    public CountdownBehavior countdownTimer;
    public ScoreDisplay scoreDisplay;
    public float clicks = 0;
    public bool match = true;

    void OnMouseDown()
    {
        clicks += 1;

        if (clicks >= 2 && countdownTimer.CountdownTimer > 0 && match)
        {
            scoreDisplay.score += 1;
            scoreDisplay.UpdateScoreText();
            pool.DestroyRecipe();
            pool.SpawnRecipe();
        }
        if (!match && countdownTimer.CountdownTimer > 0)
        {
            pool.DestroyRecipe();
            pool.SpawnRecipe();
        }
        
    }
}
