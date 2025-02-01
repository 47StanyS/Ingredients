using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float _spawnTime;

    [Header("Ingredients")]
    [SerializeField][Range (0, 1)] public float[] _spawnRate;
    [SerializeField] private GameObject[] _ingredientsPrefabs;
    [SerializeField] private Transform _ingredientsContainer;

    [Header("Objects")]
    [SerializeField] private Transform[] _spawnPoints;

    public bool _canSpawn = false;

    public static IngredientsSpawner Instance;

    private void Start()
    {
        Instance = this;
        StartCoroutine(SpawnIngredientTimer());


    }


    public void SpawnRandomIngredient() 
    {
        if (_canSpawn == true)
        {
            int randomIngredientIndex = Random.Range(0, _ingredientsPrefabs.Length);

            GameObject randomIngredient = _ingredientsPrefabs[randomIngredientIndex];

            if (Random.Range(0f, 1f) < _spawnRate[randomIngredientIndex])
            {
                Transform randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

                float randomRotation = Random.Range(0f, 360f);

                GameObject newIngredient = Instantiate(randomIngredient, randomPoint.position, Quaternion.identity, _ingredientsContainer);

                newIngredient.transform.Rotate(0, 0, randomRotation);
                Destroy(newIngredient, 10f);
            }
            else
            {
                SpawnRandomIngredient();
            }
        }

    }

    private IEnumerator SpawnIngredientTimer() 
    {
        yield return new WaitForSeconds(_spawnTime);
        SpawnRandomIngredient();
        StartCoroutine(SpawnIngredientTimer());

    }

  // public void SetSpawnRate(float[] _newRates)
  // {
  //     if(_newRates.Length == _spawnRate.Length)
  //     {
  //         _spawnRate = _newRates;
  //     }
  // }
}
