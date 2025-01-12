using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicipeSystem : MonoBehaviour
{
    public Recipe[] recipes;

    public CurrentReciepe currentReciepe;

    private void Awake()
    {
        currentReciepe = new CurrentReciepe();

        currentReciepe.ingredients = recipes[0].ingredients;
        currentReciepe.counts = recipes[0].counts;
    }

    public void AddIngredients()
    {
        
    }

    public void CraftRecipe(string _recipeName)
    {
        
    }
}

[System.Serializable]
public class CurrentReciepe 
{
    public Ingredient[] ingredients;
    public int[] counts;
}
