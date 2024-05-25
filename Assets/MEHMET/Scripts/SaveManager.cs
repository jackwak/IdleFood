using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LoadGame(); //TEST AMAÇLI
    }
    private void Update()
    {
        SaveGame(); //TEST AMAÇLI
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("playerMoney", MoneyManager.Instance.playerMoney);
        PlayerPrefs.SetInt("currentLevelId", GameManager.Instance.currentLevelId);

        PlayerPrefs.SetInt("customerRateUpgradeCurrentLevel", CustomerRateUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("foodCountRateUpgradeCurrentLevel", FoodCountRateUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("foodPrepareSpeedUpgradeCurrentLevel", FoodPrepareSpeedUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("takingOrderTimeUpgradeCurrentLevel", TakingOrderTimeUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("addWaiterUpgradeCurrentLevel", AddWaiterUpgrade.Instance.currentLevel);
    }

    public void LoadGame() 
    {
        MoneyManager.Instance.playerMoney = PlayerPrefs.GetFloat("playerMoney");
        GameManager.Instance.currentLevelId = PlayerPrefs.GetInt("currentLevelId");

        CustomerRateUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("customerRateUpgradeCurrentLevel");
        FoodCountRateUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("foodCountRateUpgradeCurrentLevel");
        FoodPrepareSpeedUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("foodPrepareSpeedUpgradeCurrentLevel");
        TakingOrderTimeUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("takingOrderTimeUpgradeCurrentLevel");
        AddWaiterUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("addWaiterUpgradeCurrentLevel");

        Debug.Log("LoadGame Çalýþtý");
        UpgradeManager.Instance.SetAllUpgradesForStart(); //Tüm upgradelerin seviyesine göre ayarlamalarý baþlatýr.
    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("playerMoney", 0);
        PlayerPrefs.SetInt("currentLevelId", 1);

        PlayerPrefs.SetInt("customerRateUpgradeCurrentLevel", 1);
        PlayerPrefs.SetInt("foodCountRateUpgradeCurrentLevel", 1);
        PlayerPrefs.SetInt("foodPrepareSpeedUpgradeCurrentLevel", 1);
        PlayerPrefs.SetInt("takingOrderTimeUpgradeCurrentLevel", 1);
        PlayerPrefs.SetInt("addWaiterUpgradeCurrentLevel", 1);
    }

}
