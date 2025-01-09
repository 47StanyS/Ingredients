using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bin"))
        {
            GameController.instance.CollectCoinPlus();
        }
        else if (collision.gameObject.CompareTag("Pot"))
        {
            GameController.instance.CollectCoinMinus();
        }
    }
}
