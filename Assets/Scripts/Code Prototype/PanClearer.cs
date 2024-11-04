using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanClearer : MonoBehaviour
{
    public IngredientMover ingredientMover;

    private void OnMouseDown()
    {
        DestroyIngredients();
        ResetIngredientMover();
    }

    private void DestroyIngredients()
    {
        for (int i = 1; i <= 3; i++)
        {
            GameObject ingredient = GameObject.Find("Ingredient " + i);
            if (ingredient != null)
            {
                Destroy(ingredient);
            }
        }
    }

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