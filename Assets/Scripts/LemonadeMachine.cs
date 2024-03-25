using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LemonadeMachine : Machine
{
    public override GameObject PrepareFood()
    {
        FoodPreparingPrefab.SetActive(true);
        
        //play machine prepare anim

        float timer = 0;

        while (DispenseTime > timer)
        {
            timer += Time.deltaTime;
        }

        FoodPreparingPrefab.SetActive(false);

        GameObject foodGO = GetFoodFromPool();

        return foodGO;
    }
}
