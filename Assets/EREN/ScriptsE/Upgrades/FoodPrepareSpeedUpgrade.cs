using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodPrepareSpeedUpgrade : MonoBehaviour
{
    public static FoodPrepareSpeedUpgrade Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }


    //[SerializeField] TextMeshProUGUI titleText;
    //[SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI levelText;
    [Space]
    [SerializeField] public List<MachineData> machineData;

    //[Header("Texts")]
    //public string upgradeTitle;
    //public string upgradeDescription;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Main Stats")]
    [SerializeField] public int currentLevel;
    [SerializeField] public int maxLevel = 5;
    [Space(10)]
    [SerializeField] public float currentPrepareSpeed;
    [SerializeField] public float currentRequiredMoney;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Level 1")]
    [SerializeField, Range(0, 10)] private float _level1PrepareSpeed;
    [SerializeField] private float _level1RequiredMoney;

    [Header("Level 2")]
    [SerializeField, Range(0, 10)] private float _level2PrepareSpeed;
    [SerializeField] private float _level2RequiredMoney;

    [Header("Level 3")]
    [SerializeField, Range(0, 10)] private float _level3PrepareSpeed;
    [SerializeField] private float _level3RequiredMoney;

    [Header("Level 4")]
    [SerializeField, Range(0, 10)] private float _level4PrepareSpeed;
    [SerializeField] private float _level4RequiredMoney;

    [Header("Level 5")]
    [SerializeField, Range(0, 10)] private float _level5PrepareSpeed;
    [SerializeField] private float _level5RequiredMoney;

    public void MakeUpgrade()
    {
        if (currentLevel < maxLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    currentLevel++;
                    currentPrepareSpeed = _level2PrepareSpeed;
                    currentRequiredMoney = _level3RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 2:
                    currentLevel++;
                    currentPrepareSpeed = _level3PrepareSpeed;
                    currentRequiredMoney = _level4RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 3:
                    currentLevel++;
                    currentPrepareSpeed = _level4PrepareSpeed;
                    currentRequiredMoney = _level5RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 4:
                    currentLevel++;
                    currentPrepareSpeed = _level5PrepareSpeed;
                    //currentRequiredMoney = _level6RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
            }
        }
        if (currentLevel == maxLevel)
        {
            currentRequiredMoney = 0;
            moneyText.text = "MAX";
            levelText.text = currentLevel.ToString();
        }
    }

    //public void ResetUpgrade()
    //{
    //    currentLevel = 1;
    //    currentPrepareSpeed = _level1PrepareSpeed;
    //    currentRequiredMoney = _level2RequiredMoney;

    //    //titleText.text = upgradeTitle;
    //    //descriptionText.text = upgradeDescription;
    //    moneyText.text = currentRequiredMoney.ToString();
    //    levelText.text = currentLevel.ToString();
    //}

    public void ResetUpgrade()
    {
        switch (currentLevel)
        {
            case 0:
                currentLevel = 1;
                currentPrepareSpeed = _level1PrepareSpeed;
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 1:
                currentPrepareSpeed = _level1PrepareSpeed;
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 2:
                currentPrepareSpeed = _level2PrepareSpeed;
                currentRequiredMoney = _level3RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 3:
                currentPrepareSpeed = _level3PrepareSpeed;
                currentRequiredMoney = _level4RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 4:
                currentPrepareSpeed = _level4PrepareSpeed;
                currentRequiredMoney = _level5RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 5:
                currentPrepareSpeed = _level5PrepareSpeed;
                //currentRequiredMoney = _level6RequiredMoney;
                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
        }

        if (currentLevel == maxLevel)
        {
            currentRequiredMoney = 0;
            moneyText.text = "MAX";
            levelText.text = currentLevel.ToString();
        }
    }

}
