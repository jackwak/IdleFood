using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour
{
    private const int POOL_SIZE = 10;
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
            GameObject lemonade = Instantiate(MachineData.FoodPrefab, Vector3.zero, Quaternion.identity);
            lemonade.SetActive(false);
            FoodPool.Enqueue(lemonade);
        }

        FoodPreparingGameobject.SetActive(false);
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

    public abstract IEnumerator ShowPreparingFood();

}
