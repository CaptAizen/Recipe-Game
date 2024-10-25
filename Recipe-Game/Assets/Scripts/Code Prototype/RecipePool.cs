using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipePool : MonoBehaviour
{
    public List<RecipeObject> recipeObjects = new List<RecipeObject>();

    public List<GameObject> currentRecipe = new List<GameObject>();

    // Start is called before the first frame update

    void Start()
    {
        recipeObjects.Add(new RecipeObject("Secret Ingredient", 0, Resources.Load("Ingredients/Secret Ingredient") as GameObject));
        recipeObjects.Add(new RecipeObject("Steak", 1, Resources.Load("Ingredients/Steak") as GameObject));
        recipeObjects.Add(new RecipeObject("Chicken", 2, Resources.Load("Ingredients/Chicken leg") as GameObject));
        recipeObjects.Add(new RecipeObject("Onion", 3, Resources.Load("Ingredients/Onion") as GameObject));
        recipeObjects.Add(new RecipeObject("Garlic", 4, Resources.Load("Ingredients/Garlic") as GameObject));
        recipeObjects.Add(new RecipeObject("Potato", 5, Resources.Load("Ingredients/Potato") as GameObject));


        SpawnRecipe();
    }




    public void SpawnRecipe()
    {
        var RecipeIngredientOneID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientTwoID = UnityEngine.Random.Range(0, recipeObjects.Count);
        var RecipeIngredientThreeID = UnityEngine.Random.Range(0, recipeObjects.Count);

        GameObject RecipeIngredientOne = Instantiate(recipeObjects[RecipeIngredientOneID].Prefab);
        GameObject RecipeIngredientTwo = Instantiate(recipeObjects[RecipeIngredientTwoID].Prefab);
        GameObject RecipeIngredientThree = Instantiate(recipeObjects[RecipeIngredientThreeID].Prefab);

        Vector3 RecipeIngredientOnePosition = RecipeIngredientOne.transform.position;
        Vector3 RecipeIngredientTwoPosition = RecipeIngredientTwo.transform.position;
        Vector3 RecipeIngredientThreePosition = RecipeIngredientThree.transform.position;

        RecipeIngredientOne.transform.position = new Vector3((float)1.6, 0, (float)-1.4);
        RecipeIngredientTwo.transform.position = new Vector3((float)1.6, 0, (float)-.4);
        RecipeIngredientThree.transform.position = new Vector3((float)1.6, 0, 1);

        RecipeIngredientOne.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientTwo.transform.localScale = new Vector3((float).47, (float).47, (float).47);
        RecipeIngredientThree.transform.localScale = new Vector3((float).47, (float).47, (float).47);

        currentRecipe.Add(RecipeIngredientOne);
        currentRecipe.Add(RecipeIngredientTwo);
        currentRecipe.Add(RecipeIngredientThree);
    }




    public void DestroyRecipe()
    {
        foreach (var RecipeIngredientOne in currentRecipe)
        {
            Destroy(RecipeIngredientOne);
        }
        foreach (var RecipeIngredientTwo in currentRecipe)
        {
            Destroy(RecipeIngredientTwo);
        }
        foreach (var RecipeIngredientThree in currentRecipe)
        {
            Destroy(RecipeIngredientThree);
        }
        currentRecipe.Clear();
    }
}
