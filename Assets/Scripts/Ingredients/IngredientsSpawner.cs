using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float _spawnTime;

    [Header("Ingredients")]
    [SerializeField][Range (0, 1)] private float[] _spawnRate;
    [SerializeField] private GameObject[] _ingredientsPrefabs;
    [SerializeField] private Transform _ingredientsContainer;

    [Header("Objects")]
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnIngredientTimer());
    }

    public void SpawnRandomIngredient() 
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

    private IEnumerator SpawnIngredientTimer() 
    {
        yield return new WaitForSeconds(_spawnTime);
        SpawnRandomIngredient();

        StartCoroutine(SpawnIngredientTimer());
    }
}
