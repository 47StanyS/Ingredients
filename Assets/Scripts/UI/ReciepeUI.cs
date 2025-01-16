using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciepeUI : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;

    private List<ReciepeCell> spawnedCells = new List<ReciepeCell>();

    private RicipeSystem ricipeSystem;

    private void Start()
    {
        ricipeSystem = RicipeSystem.Instance;
    }

    public void NewReciepe(Recipe newReciepe) 
    {
        if(spawnedCells.Count > 0) 
        {
            for (int i = 0; i < spawnedCells.Count; i++)
            {
                Destroy(spawnedCells[i].gameObject);
            }

            spawnedCells.Clear();
        }

        for (int i = 0; i < newReciepe.ingredients.Count; i++)
        {
            spawnedCells.Add(Instantiate(cellPrefab, transform).GetComponent<ReciepeCell>());
        }

        Refresh();
    }

    public void Refresh() 
    {
        for (int i = 0; i < spawnedCells.Count; i++)
        {
            spawnedCells[i].icon.sprite = ricipeSystem.currentReciepe.originalReciepe.ingredients[i].GetComponent<SpriteRenderer>().sprite;

            int currentCount = ricipeSystem.currentReciepe.originalReciepe.counts[i] - ricipeSystem.currentReciepe.counts[i];
            currentCount = Mathf.Clamp(currentCount, 0, ricipeSystem.currentReciepe.originalReciepe.counts[i]);

            spawnedCells[i].countText.text = currentCount.ToString();
        }
    }
}
