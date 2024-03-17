using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private string[] allFoods;
    public List<string> buyableFoods;

    void Start()
    {
        allFoods = new string[1];
        allFoods[0] = "limonata";


    }

    public string ChooseRandomBuyableFood()
    {
        if (buyableFoods.Count == 0)
        {
            Debug.Log("HATA: Satýn alýnabilecek yemek listesi boþ!!");
            return null;
        }
        else
        {
            int range = UnityEngine.Random.Range(0, buyableFoods.Count);
            return buyableFoods[range];
        }
    }


    public void AddBuyableFood(string foodName)
    {
        buyableFoods.Add(foodName);
    }
    public void ResetBuyabeFoods()
    {
        buyableFoods.Clear();
    }


}
