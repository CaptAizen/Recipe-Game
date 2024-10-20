using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawtoCookedtoBurnt : MonoBehaviour
{
    private Renderer ingredientRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ingredientRenderer = GetComponent<Renderer>();
    }

public void SetColor(Color newColor)
    {
        if (ingredientRenderer != null)
        {
            ingredientRenderer.material.color = newColor;
        }
    }