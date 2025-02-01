using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject _cookingScreen;

    public static GameController instance;
    private RicipeSystem _ricipeSystem;
    private IngredientsSpawner _ingredientsSpawner;

    public int _complitedRecipeCount = 0;

    private void Awake()
    {
        instance = this;
        _ricipeSystem = RicipeSystem.Instance;
        _ingredientsSpawner = IngredientsSpawner.Instance;
    }

    private void Start()
    {
        _ingredientsSpawner = IngredientsSpawner.Instance;

        if (_ingredientsSpawner == null)
        {
           // Debug.LogWarning("⚠️ IngredientsSpawner.Instance == null, шукаємо вручну...");
            _ingredientsSpawner = FindObjectOfType<IngredientsSpawner>();
        }
    }
    private void Update()
    {
        CookingScreenOpen();
    }
    public void CookingScreenOpen()
    {
       // Debug.Log($"_cookingScreen: {_cookingScreen}");
       // Debug.Log($"_ingredientsSpawner: {_ingredientsSpawner}");

        if (_cookingScreen == null || _ingredientsSpawner == null)
        {
            // Debug.LogError("❌ CookingScreen або IngredientsSpawner не ініціалізовані!");
            return;
        }
        if (_complitedRecipeCount == 1)
        {
            _complitedRecipeCount = 0;
            _cookingScreen.SetActive(true);
            _ingredientsSpawner._canSpawn = false;
            
        }
    }
}
