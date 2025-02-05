using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/Difficulty", order = 0)]
public class DifficultyLevel : ScriptableObject
{
    [SerializeField][Range(0, 1)] public float[] spawnRate;
}
