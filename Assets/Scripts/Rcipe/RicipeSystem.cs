using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicipeSystem : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();

    public CurrentReciepe currentReciepe = new CurrentReciepe();

    public static RicipeSystem Instance;

    private void Awake()
    {
        Instance = this;

        Recipe[] newRecipes = Resources.LoadAll<Recipe>("Recipes");

        for (int i = 0; i < newRecipes.Length; i++) 
        {
            recipes.Add(newRecipes[i]);
        }

        CraftRecipe();
    }

    public void AddIngredients(Ingredient newIngredient)
    {
        for (int i = 0; i < currentReciepe.ingredients.Count; i++) 
        {
            if (currentReciepe.ingredients[i].nameIngredient == newIngredient.nameIngredient) 
            {
                currentReciepe.counts[i]++;
                break;
            }
        }

        bool isReady = true;

        for (int i = 0; i < currentReciepe.ingredients.Count; i++)
        {
            if (currentReciepe.counts[i] < currentReciepe.originalReciepe.counts[i]) 
            {
                isReady = false;
                break;
            }
        }

        if (isReady == true) 
        {
            recipes.Remove(currentReciepe.originalReciepe);
            CraftRecipe();

            GroundManager.Instance.ReciepeCrafted();
        }
    }

    public void CraftRecipe()
    {
        currentReciepe.ingredients = recipes[0].ingredients;
        currentReciepe.counts = new int[recipes[0].counts.Length];

        currentReciepe.originalReciepe = recipes[0];
    }
}

[System.Serializable]
public class CurrentReciepe 
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public int[] counts;

    public Recipe originalReciepe;
}
