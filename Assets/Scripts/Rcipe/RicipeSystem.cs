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

    public void CraftRecipe(string _recipeName)
    {
        switch (_recipeName)
        {
            case "CircleTriangle":
                if (_collectedIngredients[(int)IngredientType.Capsule] >= 2 &&
                    _collectedIngredients[(int)IngredientType.Circle] >= 1 &&
                    _collectedIngredients[(int)IngredientType.Triangle] >= 1)
                {
                    _collectedIngredients[(int)IngredientType.Capsule] -= 2;
                    _collectedIngredients[(int)IngredientType.Circle] -= 1;
                    _collectedIngredients[(int)IngredientType.Triangle] -= 1;

                    Debug.Log("nice,you have soup");
                }
                else
                {
                    Debug.Log("missing ingredients");
                }
                break;
        }
    }
}
