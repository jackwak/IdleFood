using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameObject CustomerManagerObj;
    [HideInInspector] private CustomerManager customerManager;

    [Header("All Upgrade Objects")]
    [SerializeField] private GameObject CustomerRateUpgradeObj;
    [HideInInspector] private CustomerRateUpgrade customerRateUpgrade;

    [SerializeField] private GameObject FoodCountRateUpgradeObj;
    [HideInInspector] private FoodCountRateUpgrade foodCountRateUpgrade;

    private void Start()
    {
        customerManager = CustomerManagerObj.GetComponent<CustomerManager>();
        customerRateUpgrade = CustomerRateUpgradeObj.GetComponent<CustomerRateUpgrade>();
        foodCountRateUpgrade = FoodCountRateUpgradeObj.GetComponent<FoodCountRateUpgrade>();

        ResetAllUpgrades();
    }


    public void CustomerRateUpgradeButton()
    {
        //Önce ne kadar parasý var kontrol et yeterlisye çalýþtýr ve parayý azalt
        //if(Player.money >= customerRateUpgrade.currentWantedMoney)
        //{

        //}

        float rate = customerRateUpgrade.MakeUpgrade();
        customerManager.musteriOlmaSansii = rate;
    }
    public void FoodCountRateUpgradeButton()
    {
        //Önce ne kadar parasý var kontrol et yeterlisye çalýþtýr ve parayý azalt
        //if(Player.money >= foodCountRateUpgrade.currentWantedMoney)
        //{

        //}

        foodCountRateUpgrade.MakeUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.OneFood();
        customerManager.ikiYemekSansi = foodCountRateUpgrade.TwoFood();
        customerManager.ucYemekSansi = foodCountRateUpgrade.ThreeFood();
    }




    public void ResetAllUpgrades()  //Hem Customer Manager'ý sýfýrlar, hem tüm upgrade objelerini.
    {
        customerRateUpgrade.ResetUpgrade();
        customerManager.musteriOlmaSansii = customerRateUpgrade._startRate;

        foodCountRateUpgrade.ResetUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.OneFood();
        customerManager.ikiYemekSansi = foodCountRateUpgrade.TwoFood();
        customerManager.ucYemekSansi = foodCountRateUpgrade.ThreeFood();
    }
}
