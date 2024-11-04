using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public RecipePool pool; // Reference to RecipePool
    public CountdownBehavior countdownTimer; // Reference to CountdownBehavior
    public ScoreDisplay scoreDisplay; // Reference to ScoreDisplay
    public float clicks = 0; // Counter for clicks
    public bool match = true; // Flag to check if the recipe matches

    // Method called when the object is clicked
    void OnMouseDown()
    {
        clicks += 1;

        // Check if the number of clicks is greater than or equal to 2 and the countdown timer is greater than 0
        if (clicks >= 2 && countdownTimer.CountdownTimer > 0)
        {
            match = CheckRecipeMatch(); // Check if the recipe matches
            if (match)
            {
                int scoreChange = CalculateScore(); // Calculate the score change
                scoreDisplay.score += scoreChange; // Update the score
                scoreDisplay.UpdateScoreText(); // Update the score text
            }
            ClearPan(); // Clear the pan
            pool.DestroyRecipe(); // Destroy the current recipe
            pool.SpawnRecipe(); // Spawn a new recipe
        }
        if (!match && countdownTimer.CountdownTimer > 0)
        {
            ClearPan(); // Clear the pan
            pool.DestroyRecipe(); // Destroy the current recipe
            pool.SpawnRecipe(); // Spawn a new recipe
        }
        if (countdownTimer.CountdownTimer == 0)
        {
            clicks = 0; // Reset the click counter
        }
    }

    // Method to check if the recipe matches
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

    // Method to calculate the score change
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

    // Method to clear the pan
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
