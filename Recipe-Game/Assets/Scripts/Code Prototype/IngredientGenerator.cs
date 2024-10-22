using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGenerator : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

    // Start is called before the first frame update
    public void SpawnIngredients()
    {
        for(int i = 0; i < ingredients.Count; i++)
        {
            GameObject tempObj = Instantiate(ingredients[i].Prefab);
            tempObj.name = i.ToString();
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + ((float)-5 + i * (float)2), tempV3.y + ((float)0), tempV3.z + ((float)-3.89));
            tempObj.AddComponent<IngredientMover>();

            IngredientMover mover = tempObj.AddComponent<IngredientMover>();
            mover.ingredientGenerator = this;
            mover.ingredientIndex = ingredients[i].Id;
        }
    }
    void Start()
    {
        ingredients.Add(new Ingredient("Secret Ingredient", 0, Resources.Load("Ingredients/Secret Ingredient") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Steak", 1, Resources.Load("Ingredients/Steak") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Chicken", 2, Resources.Load("Ingredients/Chicken leg") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Onion", 3, Resources.Load("Ingredients/Onion") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Garlic", 4, Resources.Load("Ingredients/Garlic") as GameObject, -1, 2, -2, 2, 4, 0));
        ingredients.Add(new Ingredient("Potato", 5, Resources.Load("Ingredients/Potato") as GameObject, -1, 2, -2, 2, 4, 0));

        

        SpawnIngredients();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
