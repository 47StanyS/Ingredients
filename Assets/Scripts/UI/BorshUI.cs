using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorshUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private IngredientsSpawner _ingredientsSpawner;

    [SerializeField] private GameObject _recieptScreenOne;
    [SerializeField] private GameObject _recieptScreenTwo;

    private void Awake()
    {
        //_ingredientsSpawner._canSpawn = false;
        _ingredientsSpawner = IngredientsSpawner.Instance;
    }
    private void Start()
    {

        if (_ingredientsSpawner == null)
        {
            _ingredientsSpawner = FindObjectOfType<IngredientsSpawner>();
        }
        //_ingredientsSpawner._canSpawn = false;
    }

    //private bool _pressed = false;
    public void PlayGame()
    {
        _recieptScreenTwo.SetActive(false);
        _ingredientsSpawner._canSpawn = true;
    }
    public void ScreenChange()
    {
        _recieptScreenOne.SetActive(false);
    }
}
