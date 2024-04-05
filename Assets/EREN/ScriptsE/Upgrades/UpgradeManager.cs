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

    [Header("All Upgrade Objects")]
    [SerializeField] private GameObject CustomerRateUpgradeObj;
    [SerializeField] private GameObject FoodCountRateUpgradeObj;



    private CustomerManager customerManager;
    private CustomerRateUpgrade customerRateUpgrade;
    private FoodCountRateUpgrade foodCountRateUpgrade;

    private void Start()
    {
        customerManager = CustomerManagerObj.GetComponent<CustomerManager>();
        customerRateUpgrade = CustomerRateUpgradeObj.GetComponent<CustomerRateUpgrade>();
        foodCountRateUpgrade = FoodCountRateUpgradeObj.GetComponent<FoodCountRateUpgrade>();

        ResetAllUpgrades();

    }



    //====================================UPGRADE D��MELER� FONKS�YONLARI
    public void CustomerRateUpgradeButton()
    {
        //�nce ne kadar paras� var kontrol et yeterlisye �al��t�r ve paray� azalt
        //if(Player.money >= customerRateUpgrade.currentWantedMoney)
        //{
                
        //}

        customerManager.musteriOlmaSansii = customerRateUpgrade.MakeUpgrade();
    }
    public void FoodCountRateUpgradeButton()
    {
        //�nce ne kadar paras� var kontrol et yeterlisye �al��t�r ve paray� azalt
        //if(Player.money >= foodCountRateUpgrade.currentWantedMoney)
        //{

        //}

        foodCountRateUpgrade.MakeUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
        customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
        customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;
    }


    //====================================D��ER
    public void ResetAllUpgrades()  //Hem Customer Manager'� s�f�rlar, hem t�m upgrade objelerini.
    {
        customerRateUpgrade.ResetUpgrade();
        customerManager.musteriOlmaSansii = customerRateUpgrade.currentRate;

        foodCountRateUpgrade.ResetUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
        customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
        customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;
    }
    public void SetGrayOrGreenButton()    //Gri buton yada ye�il buton.
    {
        for (int i = 0; i < UpgradesObj.transform.childCount; i++)
        {
            GameObject childObj = UpgradesObj.transform.GetChild(i).gameObject;
            if (childObj.name.Contains("CustomerRateUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                //if (player.money < customerRateUpgrade.currentWantedMoney)
                //{
                //    moneyImage.sprite = grayButton;
                //}
                //else
                //{
                //    moneyImage.sprite = greenButton;
                //}
            }
            else if (childObj.name.Contains("FoodCountRateUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                //if (player.money < foodCountRateUpgrade.currentWantedMoney)
                //{
                //    moneyImage.sprite = grayButton;
                //}
                //else
                //{
                //    moneyImage.sprite = greenButton;
                //}
            }

        }
    }

}
