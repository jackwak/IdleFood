using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;


    [SerializeField] private TMP_Text moneyText;
    [SerializeField] public float playerMoney;

    [Header("Other")]
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private GameObject upgradePanelObj;
    [SerializeField] private List<UpgradeMachineController> upgradeMachineControllerList;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);

        //DontDestroyOnLoad(Instance);
    }



    private void Update() //Oyunun son halinde kaldýr
    {
        UpdateMoneyText(); 
        CheckMoneyForUpgradeButtonGreenOrGray();
        CheckMoneyForFoodMachineUpgradeButton();
    }

    public void AddMoney(float money)
    {
        playerMoney += money;
        UpdateMoneyText();
        CheckMoneyForUpgradeButtonGreenOrGray();
        CheckMoneyForFoodMachineUpgradeButton();
    }
    public void RemoveMoney(float money)
    {
        playerMoney -= money;
    }
    public void UpdateMoneyText()
    {
        moneyText.text = ((int)playerMoney).ToString();
    }
    public void CheckMoneyForUpgradeButtonGreenOrGray()
    {
        if (upgradePanelObj.activeSelf)
        {
            upgradeManager.SetGrayOrGreenButton();
        }
    }
    public void CheckMoneyForFoodMachineUpgradeButton()
    {
        if(upgradeMachineControllerList.Count > 0)
        {
            for (int i = 0; i < upgradeMachineControllerList.Count; i++)
            {
                if (playerMoney >= upgradeMachineControllerList[i].MachineData_UpgradePriceProp && !upgradeMachineControllerList[i].gameObject.transform.GetChild(0).GetChild(0).gameObject.activeSelf)
                {
                    upgradeMachineControllerList[i].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    upgradeMachineControllerList[i].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

}
