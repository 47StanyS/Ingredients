using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Space]
    [Header("CoinsSettings")]
    public int _coins;

    //[SerializeField] private int _minusCoin = 5;

    //[SerializeField] private TMP_Text _coinsText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoinPlus()
    {
        //_coins++;
        //_coinsText.text = _coins.ToString();
    }
    public void CollectCoinMinus()
    {
        //_coins = _coins - _minusCoin;
        //_coinsText.text = _coins.ToString();
    }
}
