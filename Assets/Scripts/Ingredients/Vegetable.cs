using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    [SerializeField] private IngredientType _ingredientType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            FindObjectOfType<RicipeSystem>().AddIngredients(_ingredientType);
            GameController.instance.CollectCoinPlus();
        }
        else if (collision.gameObject.CompareTag("Bin"))
        {
            GameController.instance.CollectCoinMinus();
        }
    }
}
