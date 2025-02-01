using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPotBin : MonoBehaviour
{
    private int _currentIndex = 0;

    [SerializeField] private GameObject[] _states;
    [SerializeField] private Button _swithButton;

    private BoxCollider2D boxCollider2d;

    private void Awake()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        if (_swithButton != null)
        {
            _swithButton.onClick.AddListener(SwitchState);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        _states[_currentIndex].SetActive(false);

        if (_currentIndex == 0) _currentIndex = 1;
        else _currentIndex = 0;

        SetActivePlayer();

        StartCoroutine(ColliderReload());
    }
    private void SetActivePlayer()
    {
        _states[_currentIndex].SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_currentIndex == 0)
        {
            if (collision.gameObject.CompareTag("Vegetable")) 
            {
                RicipeSystem.Instance.AddIngredients(collision.gameObject.GetComponent<Ingredient>());

                //GameController.instance.CollectCoinPlus();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Trash"))
            {
                //GameController.instance.CollectCoinMinus();
            }

        } else if (_currentIndex == 1)
        {
            if (collision.gameObject.CompareTag("Vegetable"))
            {
               // GameController.instance.CollectCoinMinus();
            }
            else if (collision.gameObject.CompareTag("Trash"))
            {
                //GameController.instance.CollectCoinPlus();
                Destroy(collision.gameObject);
            }
        }
    }

    private IEnumerator ColliderReload() 
    {
        boxCollider2d.enabled = false;
        yield return new WaitForSeconds(0.01f);
        boxCollider2d.enabled = true;
    }
}
