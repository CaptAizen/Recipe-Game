using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeObject
{
    public string Name;
    public int id;
    public GameObject Prefab;

    public RecipeObject(string name, int Id, GameObject prefab)
    {
        Name = name;
        id = Id;
        Prefab = prefab;
    }
}