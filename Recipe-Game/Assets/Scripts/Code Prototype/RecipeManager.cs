using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public string Name { get; set; }
    public int Id { get; set; }
    public GameObject Prefab { get; set; }
    public int PointValueRaw { get; set; }
    public int PointValueCooked { get; set; }
    public int PointValueBurnt { get; set; }
    public float CookingTime { get; set; }
    public float BurningTime { get; set; }
    // Start is called before the first frame update
    public void SpawnIngredients()
    {
        for(int i = 0; i < ingredients.Count; i++)
        {
            GameObject tempObj = Instantiate(ingredients[i].Prefab);
            tempObj.name = i.ToString();
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + ((float)-5 + i * (float)2), tempV3.y + ((float)0), tempV3.z + ((float)-3.89));
        }
    }
    void Start()
    {
        ingredients.Add(new Ingredient("Potato", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));
        ingredients.Add(new Ingredient("Steak", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));
        ingredients.Add(new Ingredient("Chicken", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));
        ingredients.Add(new Ingredient("Onion", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));
        ingredients.Add(new Ingredient("Garlic", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));
        ingredients.Add(new Ingredient("Secret Ingredient", 0, Resources.Load("Ingredients/Apple") as GameObject, -1, 2, -2, 2, 4));

        SpawnIngredients();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
