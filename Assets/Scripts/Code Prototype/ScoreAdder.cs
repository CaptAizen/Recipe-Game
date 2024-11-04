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

        if (clicks >= 2 && countdownTimer.CountdownTimer > 0)
        {
            match = CheckRecipeMatch();
            if (match)
            {
                int scoreChange = CalculateScore();
                scoreDisplay.score += scoreChange;
                scoreDisplay.UpdateScoreText();
            }
            ClearPan();
            pool.DestroyRecipe();
            pool.SpawnRecipe();
        }
        if (!match && countdownTimer.CountdownTimer > 0)
        {
            ClearPan();
            pool.DestroyRecipe();
            pool.SpawnRecipe();
        }
        if (countdownTimer.CountdownTimer == 0)
        {
            clicks = 0;
        }
    }

    bool CheckRecipeMatch()
    {
        List<string> panIngredientNames = IngredientMover.panIngredients.ConvertAll(i => i.name);
        foreach (string name in pool.currentRecipeNames)
        {
            if (!panIngredientNames.Contains(name))
            {
                return false;
            }
        }
        return true;
    }

    int CalculateScore()
    {
        int burntCount = 0;
        foreach (GameObject ingredient in IngredientMover.panIngredients)
        {
            IngredientRemover remover = ingredient.GetComponent<IngredientRemover>();
            if (remover.currentState == IngredientRemover.CookingState.Burnt)
            {
                burntCount++;
            }
        }

        if (burntCount == 0)
        {
            return 10;
        }
        else if (burntCount == 1)
        {
            return 5;
        }
        else if (burntCount == 2)
        {
            return -5;
        }
        else // burntCount == 3
        {
            return -10;
        }
    }

   public void ClearPan()
    {
        foreach (GameObject ingredient in IngredientMover.panIngredients)
        {
            Destroy(ingredient);
        }
        IngredientMover.panIngredients.Clear();
        IngredientMover.ingredientsClicked = 0;
        IngredientMover.PositionCycler = 0;
    }
}
