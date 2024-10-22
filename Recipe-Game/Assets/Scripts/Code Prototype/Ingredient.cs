using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public string Name;
    public int Id;
    public GameObject Prefab;
    public int PointValueRaw;
    public int PointValueCooked;
    public int PointValueBurnt;
    public float CookingTime;
    public float BurningTime;

    public Ingredient(string name, int id, GameObject prefab, int pointValueRaw, int pointValueCooked, int pointValueBurnt, float cookingTime, float burningTime)
    {
        Name = name;
        Id = id;
        Prefab = prefab;
        PointValueRaw = pointValueRaw;
        PointValueCooked = pointValueCooked;
        PointValueBurnt = pointValueBurnt;
        CookingTime = cookingTime;
        BurningTime = burningTime;
    }
}