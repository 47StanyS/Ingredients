using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewReciepe", menuName = "ScriptableObjects/Reciepe", order = 1)]
public class Recipe : ScriptableObject
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public int[] counts;

    //public GameObject result;


}
