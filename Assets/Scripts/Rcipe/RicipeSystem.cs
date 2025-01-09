using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Capsule, Circle, Triangle
}
public class RicipeSystem : MonoBehaviour
{
    //RecipeSystem
    [SerializeField] private int[] _collectedIngredients = new int[System.Enum.GetValues(typeof(IngredientType)).Length];

    public void AddIngredients(IngredientType _ingredient)
    {
        _collectedIngredients[(int)_ingredient]++;
        Debug.Log($"Add{_ingredient} all{_collectedIngredients[(int)_ingredient]}");
    }
}
