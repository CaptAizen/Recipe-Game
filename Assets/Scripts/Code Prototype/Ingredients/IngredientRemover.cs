using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientRemover : MonoBehaviour
{
    public float cookTime = 0;
    public float burntTime = 0;
    public float timeSpentOnPan = 0;

    public Material rawMaterial;
    public Material cookedMaterial;
    public Material burntMaterial;

    private Renderer objectRenderer;
    private Renderer[] renderers;


    // Start is called before the first frame update

    void Start()
    {
        // Load the materials from the Resources folder
        rawMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/RawMaterial");
        cookedMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/CookedMaterial");
        burntMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/BurntMaterial");

        // Assign random cook and burn times
        cookTime = Random.Range(1f, 1.5f); // Random cook time between 5 and 10 seconds
        burntTime = Random.Range(2.5f, 4f); // Random burn time between 15 and 20 seconds

        // Get all Renderer components in the object and its children
        renderers = GetComponentsInChildren<Renderer>();

        // Set the initial materials for all renderers
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

        Destroy(gameObject);
        IngredientMover.ingredientsClicked -= 1;
    }

    void Update()
    {
        // Update the time spent on the pan
        timeSpentOnPan += Time.deltaTime;

        // Check if the object is cooked
        if (timeSpentOnPan >= cookTime && timeSpentOnPan < burntTime)
        {
            ChangeMaterials(cookedMaterial);
        }
        // Check if the object is burnt
        else if (timeSpentOnPan >= burntTime)
        {
            ChangeMaterials(burntMaterial);
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