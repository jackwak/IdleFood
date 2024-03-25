using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour
{
    private const int POOL_SIZE = 10;
    public float DispenseTime;
    public Queue<GameObject> FoodPool;
    public GameObject FoodPrefab;
    public Transform FoodPrepareTransfrom;
    public GameObject FoodPreparingPrefab;

    private void Start()
    {
        FoodPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE; ++i)
        {
            GameObject lemonade = Instantiate(FoodPrefab, Vector3.zero, Quaternion.identity);
            lemonade.SetActive(false);
            FoodPool.Enqueue(lemonade);
        }

        FoodPreparingPrefab.SetActive(false);
    }

    public GameObject GetFoodFromPool()
    {
        GameObject lemonade = FoodPool.Dequeue();
        lemonade.SetActive(true);
        return lemonade;
    }

    private void ReturnFoodToPool(GameObject food)
    {
        food.SetActive(false);
        FoodPool.Enqueue(food);
    }

    public abstract GameObject PrepareFood();

}
