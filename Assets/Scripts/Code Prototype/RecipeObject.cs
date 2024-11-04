using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeObject
{
    public string Name; // Name of the recipe object
    public int id; // ID of the recipe object
    public GameObject Prefab; // Prefab of the recipe object

    // Constructor to initialize the recipe object
    public RecipeObject(string name, int Id, GameObject prefab)
    {
        Name = name;
        id = Id;
        Prefab = prefab;
    }
}
