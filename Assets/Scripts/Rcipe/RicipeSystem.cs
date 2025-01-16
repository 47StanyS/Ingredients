using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicipeSystem : MonoBehaviour
{ 

    //ця строка відповідає за спиок рицептів яку ми отримуєм через інспектор, не розумію нашо писати "новий"
    public List<Recipe> recipes = new List<Recipe>();
    // це екземпряр поточного нового рецепту який ми зараз маємо, робиться для того щоб при завершені все що ми назбирали скидалось на нуль.
    public CurrentReciepe currentReciepe = new CurrentReciepe();
    // сінглтон, це надання доступу до об'єкту, скрипту, через скріпт(замііняє звернення по тегу, леєру)
    public static RicipeSystem Instance;



    private void Awake()
    {//ініциалізація сінглтону
        Instance = this;
        //масив рецептів, перед стартом додаються всі рецепти що є в папці ресурси 
        Recipe[] newRecipes = Resources.LoadAll<Recipe>("Recipes");
        //цикл додавання рецептів, перебераючи по довжені 
        for (int i = 0; i < newRecipes.Length; i++) 
        {
            recipes.Add(newRecipes[i]);
        }
        //метод 
        CraftRecipe();
    }
    //метод додавання інгредієнту(звернення до скріпту Інгрєдієнт запис його в змінну)
    public void AddIngredients(Ingredient newIngredient)
    {// цикил який збирає інгрідієнти за іменами і складає їх в масив цілих чисел поточного рецепту
        for (int i = 0; i < currentReciepe.ingredients.Count; i++) 
        {
            if (currentReciepe.ingredients[i].nameIngredient == newIngredient.nameIngredient) 
            {
                currentReciepe.counts[i]++;
                break;
            }
        }
        
        bool isReady = true;
        //цикл для перевірки на готовність рецепту, поки і менща за кількість зібраних інгредієнтів, то додати інгрідієнт
        for (int i = 0; i < currentReciepe.ingredients.Count; i++)
        {
            //якщо  в поточному рецепті кількість менша за кількість в оригінальному рецепті, рецепт не готов,
            //брейк(зупинка циклу)
            if (currentReciepe.counts[i] < currentReciepe.originalReciepe.counts[i]) 
            {
                isReady = false;
                break;
            }
        }
        //якщо готов, видаляється цей рецепт з списку, вмикається метод створення нового рецепту, та через сінглтон 
        //вмикається метод який опускає землю
        if (isReady == true) 
        {
            recipes.Remove(currentReciepe.originalReciepe);
            CraftRecipe();

            GroundManager.Instance.ReciepeCrafted();
        }
    }
    // метод що створює нову копію поточного з списку рецепта але з інтом на 0
    public void CraftRecipe()
    {
        currentReciepe.ingredients = recipes[0].ingredients;
        currentReciepe.counts = new int[recipes[0].counts.Length];

        currentReciepe.originalReciepe = recipes[0];
    }
}
//за допомогою цього рядка можна бачити клас в інспекторі
[System.Serializable]
//клас завдяки якому ми порівнюємо зібрану кількість з написаними вже рецептами
public class CurrentReciepe 
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public int[] counts;

    public Recipe originalReciepe;
}
