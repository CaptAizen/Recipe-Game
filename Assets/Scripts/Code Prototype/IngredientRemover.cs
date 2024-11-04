using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientRemover : MonoBehaviour
{
    // Cooking and burning times
    public float cookTime = 0;
    public float burntTime = 0;
    public float timeSpentOnPan = 0;

    // Materials for different cooking states
    public Material rawMaterial;
    public Material cookedMaterial;
    public Material burntMaterial;

    // Renderer components of the ingredient
    private Renderer objectRenderer;
    private Renderer[] renderers;

    // Enum to represent the cooking state
    public enum CookingState { Raw, Cooked, Burnt }
    public CookingState currentState = CookingState.Raw;

    void Start()
    {
        // Load materials from resources
        rawMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/RawMaterial");
        cookedMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/CookedMaterial");
        burntMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/BurntMaterial");

        // Set random cooking and burning times
        cookTime = Random.Range(1f, 1.5f);
        burntTime = Random.Range(2.5f, 4f);

        // Get all renderer components in the children of the ingredient
        renderers = GetComponentsInChildren<Renderer>();

        // Set the initial material to rawMaterial
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = rawMaterial;
            }
            renderer.materials = materials;
        }
    }

    private void OnMouseDown()
    {
        // Remove the ingredient from the pan and destroy it
        IngredientMover.panIngredients.Remove(gameObject);
        Debug.Log("Removed: " + gameObject.name);
        Debug.Log("Current Ingredients: " + string.Join(", ", IngredientMover.panIngredients.ConvertAll(i => i.name)));
        Destroy(gameObject);
        IngredientMover.ingredientsClicked -= 1;
    }

    void Update()
    {
        // Update the time spent on the pan
        timeSpentOnPan += Time.deltaTime;

        // Change the material based on the cooking state
        if (timeSpentOnPan >= cookTime && timeSpentOnPan < burntTime)
        {
            ChangeMaterials(cookedMaterial);
            currentState = CookingState.Cooked;
        }
        else if (timeSpentOnPan >= burntTime)
        {
            ChangeMaterials(burntMaterial);
            currentState = CookingState.Burnt;
        }
    }

    void ChangeMaterials(Material newMaterial)
    {
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = newMaterial;
            }
            renderer.materials = materials;
        }
    }
}