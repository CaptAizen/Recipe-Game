using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientGenerator : MonoBehaviour
{
    // List to store all possible ingredients
    public List<Ingredient> ingredients = new List<Ingredient>();
    // Parent game object for the ingredients
    private GameObject ingredientsParent;

    // Method to spawn ingredients
    public void SpawnIngredients()
    {
        // Create a new parent game object for the ingredients
        ingredientsParent = new GameObject("Ingredients");

        // Loop through the ingredients list and instantiate each ingredient
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject tempObj = Instantiate(ingredients[i].Prefab, ingredientsParent.transform);
            BoxCollider boxCollider = tempObj.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            tempObj.name = ingredients[i].Name;
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + ((float)-5 + i * (float)2), tempV3.y + ((float)0), tempV3.z + ((float)-3.89));

            // Add the IngredientMover component to the ingredient
            IngredientMover mover = tempObj.AddComponent<IngredientMover>();
            mover.ingredientGenerator = this;
            mover.ingredientIndex = ingredients[i].Id;
            mover.countdownTimer = GameObject.Find("Timer").GetComponent<CountdownBehavior>();
            mover.startGame = GameObject.Find("Pan").GetComponent<StartGame>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Adding predefined ingredients to the list
        ingredients.Add(new Ingredient("Secret Ingredient", 0, Resources.Load("Ingredients/Secret Ingredient") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Steak", 1, Resources.Load("Ingredients/Steak") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Chicken", 2, Resources.Load("Ingredients/Chicken leg") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Onion", 3, Resources.Load("Ingredients/Onion") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Garlic", 4, Resources.Load("Ingredients/Garlic") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Potato", 5, Resources.Load("Ingredients/Potato") as GameObject, -1, 2, -2, 2, 4, 0));

        // Spawn the ingredients
        SpawnIngredients();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
