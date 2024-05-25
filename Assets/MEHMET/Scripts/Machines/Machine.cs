using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour
{
    private const int POOL_SIZE = 5;
    public Queue<GameObject> FoodPool;

    [Header("References")]
    public Transform FoodPrepareTransfrom;
    public GameObject FoodPreparingGameobject;
    [HideInInspector] public Animator Animator;

    [Header("Data")]
    public MachineData MachineData;


    private void Start()
    {
        Animator = GetComponent<Animator>();


        FoodPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE; ++i)
        {
            GameObject food = Instantiate(MachineData.FoodPrefab, Vector3.zero, Quaternion.identity);
            food.SetActive(false);
            FoodPool.Enqueue(food);
        }

        FoodPreparingGameobject.SetActive(false);
    }

    public GameObject GetFoodFromPool()
    {
        GameObject food = FoodPool.Dequeue();
        food.SetActive(true);
        return food;
    }

    public void ReturnFoodToPool(GameObject food)
    {
        food.SetActive(false);
        FoodPool.Enqueue(food);
    }

    public abstract IEnumerator ShowPreparingFood();

}
