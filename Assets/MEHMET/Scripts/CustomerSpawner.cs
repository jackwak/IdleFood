using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Food[] foods;

    [SerializeField] private List<Food> sellableFoods;



    public void AddSellableFoods()
    {
        Food food = foods[sellableFoods.Count];

        sellableFoods.Add(food);
    }

    public void AddSellableFoods(Food food)
    {
        sellableFoods.Add(food);
    }
}
