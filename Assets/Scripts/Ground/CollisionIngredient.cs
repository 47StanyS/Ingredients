using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIngredient : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            //Destroy(collision.gameObject);
        }
    }
}
