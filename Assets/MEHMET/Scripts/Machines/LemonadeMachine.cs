using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LemonadeMachine : Machine
{
    public override IEnumerator ShowPreparingFood()
    {
        FoodPreparingGameobject.SetActive(true);
        yield return new WaitForSeconds(MachineData.DispenseTime);
        FoodPreparingGameobject.SetActive(false);
    }
}
