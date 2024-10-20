using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInitializing : MonoBehaviour
{
    public GameObject[] ingredientPrefabs;
    public Vector3[] positions;

    // Start is called before the first frame update
    void Start()
    {
        Ingredient[] ingredients = new Ingredient(ingredientPrefabs[i], positions[i], Quaternion.identity);

        for (int i = 0;i < ingredientPrefabs.Length; ingredientPrefabs++)
            {
            GameObject instance = Instantiate(ingredientPrefabs[i], positions[i], Quaternion.identity);
            }

        ingredients[i] = new Ingredient(
              "Ingredient" + i,
                instance,
                Random.Range(1, 10),
                Random.Range(10, 20),
                Random.Range(5, 15),
                Random.Range(1.0f, 5.0f),
                Random.Range(5.0f, 10.0f)
            );

        instance.name = ingredients.Name;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
