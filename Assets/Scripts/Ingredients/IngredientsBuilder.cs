using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _prefab1;
    [SerializeField] private GameObject _prefab2;
    [SerializeField] private GameObject _prefab3;

    private void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-4.0f, 4.0f);
            int randomY = Random.Range(15, 70);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            Instantiate(_prefab1, spawnPosition, Quaternion.identity);
            Instantiate(_prefab2, spawnPosition, Quaternion.identity);
            Instantiate(_prefab3, spawnPosition, Quaternion.identity);
        }
    }
}
