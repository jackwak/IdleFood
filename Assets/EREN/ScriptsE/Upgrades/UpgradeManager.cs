using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

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
    [SerializeField] private TakingOrderTimeUpgrade takingOrderTimeUpgrade;
    [SerializeField] private AddWaiterUpgrade addWaiterUpgrade;


    private CustomerManager customerManager;
    //private CustomerRateUpgrade customerRateUpgrade;
    //private FoodCountRateUpgrade foodCountRateUpgrade;

    private void Start()
    {
        customerManager = CustomerManagerObj.GetComponent<CustomerManager>();

        //SetAllUpgradesForStart();

    }



    //====================================UPGRADE DÜÐMELERÝ FONKSÝYONLARI
    public void CustomerRateUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= customerRateUpgrade.currentRequiredMoney && customerRateUpgrade.currentLevel != customerRateUpgrade.maxLevel)
        {
            MoneyManager.Instance.RemoveMoney(customerRateUpgrade.currentRequiredMoney);
            customerManager.musteriOlmaSansii = customerRateUpgrade.MakeUpgrade();

            UISounds.Instance.PlayAcceptedPurchaseSound();
        }
        else
        {
            UISounds.Instance.PlayDeclinedPurchaseSound();
        }
    }
    public void FoodCountRateUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= foodCountRateUpgrade.currentRequiredMoney && foodCountRateUpgrade.currentLevel != foodCountRateUpgrade.maxLevel)
        {
            MoneyManager.Instance.RemoveMoney(foodCountRateUpgrade.currentRequiredMoney);
            foodCountRateUpgrade.MakeUpgrade();
            customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
            customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
            customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;

            UISounds.Instance.PlayAcceptedPurchaseSound();
        }
        else
        {
            UISounds.Instance.PlayDeclinedPurchaseSound();
        }
    }
    public void FoodPrepareSpeedUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= foodPrepareSpeedUpgrade.currentRequiredMoney && foodPrepareSpeedUpgrade.currentLevel != foodPrepareSpeedUpgrade.maxLevel)
        {
            MoneyManager.Instance.RemoveMoney(foodPrepareSpeedUpgrade.currentRequiredMoney);
            foodPrepareSpeedUpgrade.MakeUpgrade();
            foreach (var item in foodPrepareSpeedUpgrade.machineData)
            {
                item.DispenseTime = foodPrepareSpeedUpgrade.currentPrepareSpeed;
            }
            //foodPrepareSpeedUpgrade.machineData.DispenseTime = foodPrepareSpeedUpgrade.currentPrepareSpeed;

            UISounds.Instance.PlayAcceptedPurchaseSound();
        }
        else
        {
            UISounds.Instance.PlayDeclinedPurchaseSound();
        }
    }
    public void TakingOrderTimeUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= takingOrderTimeUpgrade.currentRequiredMoney && takingOrderTimeUpgrade.currentLevel != takingOrderTimeUpgrade.maxLevel)
        {
            MoneyManager.Instance.RemoveMoney(takingOrderTimeUpgrade.currentRequiredMoney);
            takingOrderTimeUpgrade.MakeUpgrade();
            LevelManager.Instance._takingOrderTime = takingOrderTimeUpgrade.currentTakingOrderTime;

            UISounds.Instance.PlayAcceptedPurchaseSound();
        }
        else
        {
            UISounds.Instance.PlayDeclinedPurchaseSound();
        }
    }
    public void AddWaiterUpgradeButton()
    {
        if (MoneyManager.Instance.playerMoney >= addWaiterUpgrade.currentRequiredMoney && addWaiterUpgrade.currentLevel != addWaiterUpgrade.maxLevel)
        {
            MoneyManager.Instance.RemoveMoney(addWaiterUpgrade.currentRequiredMoney);
            addWaiterUpgrade.MakeUpgrade();

            UISounds.Instance.PlayAcceptedPurchaseSound();
        }
        else
        {
            UISounds.Instance.PlayDeclinedPurchaseSound();
        }
    }


    //====================================DÝÐER
    public void SetAllUpgradesForStart()  //Oyun baþlangýcý deðerlerini atar, hem tüm upgrade objelerini. Yalnýzca oyun baþlarken sýfýrlayabilir.
    {
        customerRateUpgrade.ResetUpgrade();
        customerManager.musteriOlmaSansii = customerRateUpgrade.currentRate;

        foodCountRateUpgrade.ResetUpgrade();
        customerManager.birYemekSansi = foodCountRateUpgrade.currentOneFoodRate;
        customerManager.ikiYemekSansi = foodCountRateUpgrade.currentTwoFoodRate;
        customerManager.ucYemekSansi = foodCountRateUpgrade.currentThreeFoodRate;

        foodPrepareSpeedUpgrade.ResetUpgrade();
        foreach (var item in foodPrepareSpeedUpgrade.machineData)
        {
            item.DispenseTime = foodPrepareSpeedUpgrade.currentPrepareSpeed;
        }

        takingOrderTimeUpgrade.ResetUpgrade();
        LevelManager.Instance._takingOrderTime = takingOrderTimeUpgrade.currentTakingOrderTime;

        addWaiterUpgrade.ResetUpgrade();

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
            else if (childObj.name.Contains("FoodPrepareSpeedUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                if (MoneyManager.Instance.playerMoney < foodPrepareSpeedUpgrade.currentRequiredMoney)
                    moneyImage.sprite = grayButton;
                else
                    moneyImage.sprite = greenButton;
            }
            else if (childObj.name.Contains("TakingOrderTimeUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                if (MoneyManager.Instance.playerMoney < takingOrderTimeUpgrade.currentRequiredMoney)
                    moneyImage.sprite = grayButton;
                else
                    moneyImage.sprite = greenButton;
            }
            else if (childObj.name.Contains("AddWaiterUpgrade"))
            {
                Image moneyImage = childObj.transform.GetChild(1).gameObject.GetComponent<Image>();

                if (MoneyManager.Instance.playerMoney < addWaiterUpgrade.currentRequiredMoney)
                    moneyImage.sprite = grayButton;
                else
                    moneyImage.sprite = greenButton;
            }

        }
    }

}
