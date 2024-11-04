using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanClearer : MonoBehaviour
{
    // Reference to the IngredientMover script
    public IngredientMover ingredientMover;

    // Method called when the pan is clicked
    private void OnMouseDown()
    {
        // Destroy all ingredients on the pan
        DestroyIngredients();
        // Reset the IngredientMover state
        ResetIngredientMover();
    }

    // Method to destroy all ingredients on the pan
    private void DestroyIngredients()
    {
        for (int i = 1; i <= 3; i++)
        {
            // Find the ingredient by name and destroy it
            GameObject ingredient = GameObject.Find("Ingredient " + i);
            if (ingredient != null)
            {
                Destroy(ingredient);
            }
        }
    }

    // Method to reset the IngredientMover state
    private void ResetIngredientMover()
    {
        IngredientMover ingredientMover = FindObjectOfType<IngredientMover>();
        if (ingredientMover != null)
        {
            IngredientMover.PositionCycler = 0;
            IngredientMover.ingredientsClicked = 0;
        }
    }
}
