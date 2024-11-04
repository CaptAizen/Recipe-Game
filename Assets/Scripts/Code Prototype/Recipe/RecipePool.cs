using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipePool : MonoBehaviour
{
    public List<RecipeObject> recipeObjects = new List<RecipeObject>();
    public List<GameObject> currentRecipe = new List<GameObject>();
    public List<string> currentRecipeNames = new List<string>();

    private GameObject recipeParent;

    void Start()
    {
        recipeObjects.Add(new RecipeObject("Secret Ingredient", 0, Resources.Load("Ingredients/Secret Ingredient") as GameObject));
        recipeObjects.Add(new RecipeObject("Steak", 1, Resources.Load("Ingredients/Steak") as GameObject));
        recipeObjects.Add(new RecipeObject("Chicken", 2, Resources.Load("Ingredients/Chicken leg") as GameObject));
        recipeObjects.Add(new RecipeObject("Onion", 3, Resources.Load("Ingredients/Onion") as GameObject));
        recipeObjects.Add(new RecipeObject("Garlic", 4, Resources.Load("Ingredients/Garlic") as GameObject));
        recipeObjects.Add(new RecipeObject("Potato", 5, Resources.Load("Ingredients/Potato") as GameObject));

        recipeParent = new GameObject("Recipe");
        SpawnRecipe();
    }

    public void SpawnRecipe()
    {
        var RecipeIngredientOneID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientTwoID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientThreeID = UnityEngine.Random.Range(0, recipeObjects.Count);

        GameObject RecipeIngredientOne = Instantiate(recipeObjects[RecipeIngredientOneID].Prefab, recipeParent.transform);
        GameObject RecipeIngredientTwo = Instantiate(recipeObjects[RecipeIngredientTwoID].Prefab, recipeParent.transform);
        GameObject RecipeIngredientThree = Instantiate(recipeObjects[RecipeIngredientThreeID].Prefab, recipeParent.transform);

        RecipeIngredientOne.name = recipeObjects[RecipeIngredientOneID].Name;
        RecipeIngredientTwo.name = recipeObjects[RecipeIngredientTwoID].Name;
        RecipeIngredientThree.name = recipeObjects[RecipeIngredientThreeID].Name;

        RecipeIngredientOne.transform.position = new Vector3((float)1.6, 0, (float)-1.4);
        RecipeIngredientTwo.transform.position = new Vector3((float)1.6, 0, (float)-.4);
        RecipeIngredientThree.transform.position = new Vector3((float)1.6, 0, 1);

        RecipeIngredientOne.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientTwo.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientThree.transform.localScale = new Vector3((float).47, (float).47, (float).47);

        currentRecipe.Add(RecipeIngredientOne);
        currentRecipe.Add(RecipeIngredientTwo);
        currentRecipe.Add(RecipeIngredientThree);

        currentRecipeNames.Add(RecipeIngredientOne.name);
        currentRecipeNames.Add(RecipeIngredientTwo.name);
        currentRecipeNames.Add(RecipeIngredientThree.name);
    }

    public void DestroyRecipe()
    {
        foreach (var ingredient in currentRecipe)
        {
            Destroy(ingredient);
        }
        currentRecipe.Clear();
        currentRecipeNames.Clear();
    }
}
