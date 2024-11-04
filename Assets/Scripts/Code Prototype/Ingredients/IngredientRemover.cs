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

    public enum CookingState { Raw, Cooked, Burnt }
    public CookingState currentState = CookingState.Raw;

    void Start()
    {
        rawMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/RawMaterial");
        cookedMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/CookedMaterial");
        burntMaterial = Resources.Load<Material>("Ingredients/Ingredient Materials/BurntMaterial");

        cookTime = Random.Range(1f, 1.5f);
        burntTime = Random.Range(2.5f, 4f);

        renderers = GetComponentsInChildren<Renderer>();

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
        IngredientMover.panIngredients.Remove(gameObject);
        Debug.Log("Removed: " + gameObject.name);
        Debug.Log("Current Ingredients: " + string.Join(", ", IngredientMover.panIngredients.ConvertAll(i => i.name)));
        Destroy(gameObject);
        IngredientMover.ingredientsClicked -= 1;
    }

    void Update()
    {
        timeSpentOnPan += Time.deltaTime;

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
