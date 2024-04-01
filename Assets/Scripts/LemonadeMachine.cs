using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LemonadeMachine : Machine
{
    public override GameObject GetFood()
    {
        GameObject foodGO = GetFoodFromPool();

        return foodGO;
    }

    public override IEnumerator ShowPreparingFood()
    {
        FoodPreparingPrefab.SetActive(true);
        yield return new WaitForSeconds(DispenseTime);
        FoodPreparingPrefab.SetActive(false);
    }
}
