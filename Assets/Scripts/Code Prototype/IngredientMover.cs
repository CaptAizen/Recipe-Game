using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMover : MonoBehaviour
{
    // References to other scripts
    public IngredientGenerator ingredientGenerator;
    public CountdownBehavior countdownTimer;
    public StartGame startGame;

    // Index of the ingredient
    public int ingredientIndex;
    // Static variables to manage ingredient positions and clicks
    public static int PositionCycler = 0;
    public static int PanIngredientLocationFinder;
    public static int ingredientsClicked = 0;

    // List to store ingredients on the pan
    public static List<GameObject> panIngredients = new List<GameObject>();

    // Predefined positions for ingredients on the pan
    public Vector3[] PanIngredientLocations = new Vector3[]
    {
        new Vector3((float)-1.46099997,(float)2.73000002,(float)1.19000006),
        new Vector3((float)-1.06900001,(float)2.73000002,(float)0.40200001),
        new Vector3((float)-0.690999985,(float)2.73000002,(float)1.13499999),
    };

    // Method called when the ingredient is clicked
    private void OnMouseDown()
    {
        // Check if the countdown timer is running and the game is on
        if (countdownTimer.CountdownTimer > 0 && startGame.gameOn)
        {
            // Move the ingredient to the pan
            MoveIngredients();
        }
    }

    // Method to move ingredients to the pan
    public void MoveIngredients()
    {
        // Check if there are less than 3 ingredients on the pan
        if (ingredientsClicked < 3)
        {
            // Determine the position for the new ingredient
            PanIngredientLocationFinder = PositionCycler % 3;
            PositionCycler += 1;
            ingredientsClicked += 1;

            // Instantiate a new ingredient and set its position
            GameObject tempObj = Instantiate(gameObject);
            tempObj.name = gameObject.name; // Retain the original name
            tempObj.transform.position = PanIngredientLocations[PanIngredientLocationFinder];
            Destroy(tempObj.GetComponent<IngredientMover>());
            tempObj.AddComponent<IngredientRemover>();

            // Add the ingredient to the list of pan ingredients
            panIngredients.Add(tempObj);
            Debug.Log("Added: " + tempObj.name);
            Debug.Log("Current Ingredients: " + string.Join(", ", panIngredients.ConvertAll(i => i.name)));
        }
    }
}
