using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawtoCookedtoBurnt : MonoBehaviour
{
    // Renderer component of the ingredient
    private Renderer ingredientRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the ingredient
        ingredientRenderer = GetComponent<Renderer>();
    }

    // Method to set the color of the ingredient
    public void SetColor(Color newColor)
    {
        if (ingredientRenderer != null)
        {
            // Change the material color of the ingredient
            ingredientRenderer.material.color = newColor;
        }
    }
}
