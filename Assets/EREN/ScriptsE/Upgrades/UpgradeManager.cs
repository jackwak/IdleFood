using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [Header("Managers & Objects")]
    [SerializeField] private GameObject CustomerManagerObj;
    [SerializeField] private GameObject UpgradesObj;

    [Header("Sprites")]
    [SerializeField] private Sprite grayButton;
    [SerializeField] private Sprite greenButton;

    [Header("Level 1 Upgrade Objects")]
    [SerializeField] private CustomerRateUpgrade customerRateUpgrade;
    [SerializeField] private FoodCountRateUpgrade foodCountRateUpgrade;
    [SerializeField] private FoodPrepareSpeedUpgrade foodPrepareSpeedUpgrade;


    private CustomerManager customerManager;
    //private CustomerRateUpgrade customerRateUpgrade;
    //private FoodCountRateUpgrade foodCountRateUpgrade;

    private void Start()
    {
        customerManager = CustomerManagerObj.GetComponent<CustomerManager>();

        ResetAllUpgrades();

    }



    //====================================UPGRADE DÜÐMELERÝ FONKSÝYONLARI
    public void CustomerRateUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= customerRateUpgrade.currentRequiredMoney)
        {
            MoneyManager.Instance.RemoveMoney(customerRateUpgrade.currentRequiredMoney);
            customerManager.musteriOlmaSansii = customerRateUpgrade.MakeUpgrade();
        }    
    }
    public void FoodCountRateUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= foodCountRateUpgrade.currentRequiredMoney)
        {
            MoneyManager.Instance.RemoveMoney(foodCountRateUpgrade.currentRequiredMoney);
            foodCountRateUpgrade.MakeUpgrade();
            customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
            customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
            customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;
        }
    }
    public void FoodPrepareSpeedUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= foodPrepareSpeedUpgrade.currentRequiredMoney)
        {
            MoneyManager.Instance.RemoveMoney(foodPrepareSpeedUpgrade.currentRequiredMoney);
            foodPrepareSpeedUpgrade.MakeUpgrade();
            //waiter.prepareSpeed = foodPrepareSpeedUpgrade.currentPrepareSpeed;
        }
    }


    //====================================DÝÐER
    public void ResetAllUpgrades()  //Hem Customer Manager'ý sýfýrlar, hem tüm upgrade objelerini.
    {
        customerRateUpgrade.ResetUpgrade();
        customerManager.musteriOlmaSansii = customerRateUpgrade.currentRate;

        foodCountRateUpgrade.ResetUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
        customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
        customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;

        foodPrepareSpeedUpgrade.ResetUpgrade();
        //Oyun baþlangýcý deðerlerini atama
    }
    public void SetGrayOrGreenButton()    //Gri buton yada yeþil buton.
    {
        for (int i = 0; i < UpgradesObj.transform.childCount; i++)
        {
            GameObject childObj = UpgradesObj.transform.GetChild(i).gameObject;
            if (childObj.name.Contains("CustomerRateUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                if (MoneyManager.Instance.playerMoney < customerRateUpgrade.currentRequiredMoney)
                    moneyImage.sprite = grayButton;
                else
                    moneyImage.sprite = greenButton;
            }
            else if (childObj.name.Contains("FoodCountRateUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                if (MoneyManager.Instance.playerMoney < foodCountRateUpgrade.currentRequiredMoney)
                    moneyImage.sprite = grayButton;
                else
                    moneyImage.sprite = greenButton;
            }

        }
    }

}
