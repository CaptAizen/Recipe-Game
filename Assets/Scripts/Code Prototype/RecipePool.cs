using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipePool : MonoBehaviour
{
    // List to store all possible recipe objects
    public List<RecipeObject> recipeObjects = new List<RecipeObject>();
    // List to store the current recipe's game objects
    public List<GameObject> currentRecipe = new List<GameObject>();
    // List to store the names of the current recipe's ingredients
    public List<string> currentRecipeNames = new List<string>();

    // Parent game object for the recipe
    private GameObject recipeParent;

    void Start()
    {
        // Adding predefined recipe objects to the list
        recipeObjects.Add(new RecipeObject("Secret Ingredient", 0, Resources.Load("Ingredients/Secret Ingredient") as GameObject));
        recipeObjects.Add(new RecipeObject("Steak", 1, Resources.Load("Ingredients/Steak") as GameObject));
        recipeObjects.Add(new RecipeObject("Chicken", 2, Resources.Load("Ingredients/Chicken leg") as GameObject));
        recipeObjects.Add(new RecipeObject("Onion", 3, Resources.Load("Ingredients/Onion") as GameObject));
        recipeObjects.Add(new RecipeObject("Garlic", 4, Resources.Load("Ingredients/Garlic") as GameObject));
        recipeObjects.Add(new RecipeObject("Potato", 5, Resources.Load("Ingredients/Potato") as GameObject));

        // Creating a new parent game object for the recipe
        recipeParent = new GameObject("Recipe");
        // Spawning a new recipe
        SpawnRecipe();
    }

    public void SpawnRecipe()
    {
        // Randomly selecting three ingredients from the recipeObjects list
        var RecipeIngredientOneID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientTwoID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientThreeID = UnityEngine.Random.Range(0, recipeObjects.Count);

        // Instantiating the selected ingredients as game objects
        GameObject RecipeIngredientOne = Instantiate(recipeObjects[RecipeIngredientOneID].Prefab, recipeParent.transform);
        GameObject RecipeIngredientTwo = Instantiate(recipeObjects[RecipeIngredientTwoID].Prefab, recipeParent.transform);
        GameObject RecipeIngredientThree = Instantiate(recipeObjects[RecipeIngredientThreeID].Prefab, recipeParent.transform);

        // Naming the instantiated game objects
        RecipeIngredientOne.name = recipeObjects[RecipeIngredientOneID].Name;
        RecipeIngredientTwo.name = recipeObjects[RecipeIngredientTwoID].Name;
        RecipeIngredientThree.name = recipeObjects[RecipeIngredientThreeID].Name;

        // Setting the position of the ingredients
        RecipeIngredientOne.transform.position = new Vector3((float)1.6, 0, (float)-1.4);
        RecipeIngredientTwo.transform.position = new Vector3((float)1.6, 0, (float)-.4);
        RecipeIngredientThree.transform.position = new Vector3((float)1.6, 0, 1);

        // Setting the scale of the ingredients
        RecipeIngredientOne.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientTwo.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientThree.transform.localScale = new Vector3((float).47, (float).47, (float).47);

        // Adding the ingredients to the current recipe lists
        currentRecipe.Add(RecipeIngredientOne);
        currentRecipe.Add(RecipeIngredientTwo);
        currentRecipe.Add(RecipeIngredientThree);

        currentRecipeNames.Add(RecipeIngredientOne.name);
        currentRecipeNames.Add(RecipeIngredientTwo.name);
        currentRecipeNames.Add(RecipeIngredientThree.name);
    }

    public void DestroyRecipe()
    {
        // Destroying all game objects in the current recipe
        foreach (var ingredient in currentRecipe)
        {
            Destroy(ingredient);
        }
        // Clearing the current recipe lists
        currentRecipe.Clear();
        currentRecipeNames.Clear();
    }
}
