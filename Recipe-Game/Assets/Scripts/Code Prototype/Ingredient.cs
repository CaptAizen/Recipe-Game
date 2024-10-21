using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public string Name { get; set; }
    public int Id { get; set; }
    public GameObject Prefab { get; set; }
    public int PointValueRaw { get; set; }
    public int PointValueCooked { get; set; }
    public int PointValueBurnt { get; set; }
    public float CookingTime { get; set; }
    public float BurningTime { get; set; }

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