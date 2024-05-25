using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodCountRateUpgrade : MonoBehaviour
{
    public static FoodCountRateUpgrade Instance;


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

    //[Header("Texts")]
    //public string upgradeTitle;
    //public string upgradeDescription;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Main Stats")]
    [SerializeField] public int currentLevel;
    [SerializeField] public int maxLevel = 5;
    [Space(10)]
    [SerializeField] public int currentOneFoodRate;
    [SerializeField] public int currentTwoFoodRate;
    [SerializeField] public int currentThreeFoodRate;
    [SerializeField] public int currentRequiredMoney;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Level 1")]
    [SerializeField] private int _level1OneFoodRate;
    [SerializeField] private int _level1TwoFoodRate;
    [SerializeField] private int _level1ThreeFoodRate;
    [SerializeField] private int _level1RequiredMoney;

    [Header("Level 2")]
    [SerializeField] private int _level2OneFoodRate;
    [SerializeField] private int _level2TwoFoodRate;
    [SerializeField] private int _level2ThreeFoodRate;
    [SerializeField] private int _level2RequiredMoney;

    [Header("Level 3")]
    [SerializeField] private int _level3OneFoodRate;
    [SerializeField] private int _level3TwoFoodRate;
    [SerializeField] private int _level3ThreeFoodRate;
    [SerializeField] private int _level3RequiredMoney;

    [Header("Level 4")]
    [SerializeField] private int _level4OneFoodRate;
    [SerializeField] private int _level4TwoFoodRate;
    [SerializeField] private int _level4ThreeFoodRate;
    [SerializeField] private int _level4RequiredMoney;

    [Header("Level 5")]
    [SerializeField] private int _level5OneFoodRate;
    [SerializeField] private int _level5TwoFoodRate;
    [SerializeField] private int _level5ThreeFoodRate;
    [SerializeField] private int _level5RequiredMoney;

    public void MakeUpgrade()
    {
        if(currentLevel < maxLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    currentLevel++;
                    currentOneFoodRate = _level2OneFoodRate;
                    currentTwoFoodRate = _level2TwoFoodRate;
                    currentThreeFoodRate = _level2ThreeFoodRate;
                    currentRequiredMoney = _level3RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 2:
                    currentLevel++;
                    currentOneFoodRate = _level3OneFoodRate;
                    currentTwoFoodRate = _level3TwoFoodRate;
                    currentThreeFoodRate = _level3ThreeFoodRate;
                    currentRequiredMoney = _level4RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 3:
                    currentLevel++;
                    currentOneFoodRate = _level4OneFoodRate;
                    currentTwoFoodRate = _level4TwoFoodRate;
                    currentThreeFoodRate = _level4ThreeFoodRate;
                    currentRequiredMoney = _level5RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 4:
                    currentLevel++;
                    currentOneFoodRate = _level5OneFoodRate;
                    currentTwoFoodRate = _level5TwoFoodRate;
                    currentThreeFoodRate = _level5ThreeFoodRate;
                    //currentRequiredMoney = _level6RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
            }
        }
        if(currentLevel == maxLevel)
        {
            currentRequiredMoney = 0;
            moneyText.text = "MAX";
            levelText.text = currentLevel.ToString();
        }
    }

    //public void ResetUpgrade()
    //{
    //    currentLevel = 1;
    //    currentOneFoodRate = _level1OneFoodRate;
    //    currentTwoFoodRate = _level1TwoFoodRate;
    //    currentThreeFoodRate = _level1ThreeFoodRate;
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
                currentOneFoodRate = _level1OneFoodRate;
                currentTwoFoodRate = _level1TwoFoodRate;
                currentThreeFoodRate = _level1ThreeFoodRate;
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 1:
                currentOneFoodRate = _level1OneFoodRate;
                currentTwoFoodRate = _level1TwoFoodRate;
                currentThreeFoodRate = _level1ThreeFoodRate;
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 2:
                currentOneFoodRate = _level2OneFoodRate;
                currentTwoFoodRate = _level2TwoFoodRate;
                currentThreeFoodRate = _level2ThreeFoodRate;
                currentRequiredMoney = _level3RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 3:
                currentOneFoodRate = _level3OneFoodRate;
                currentTwoFoodRate = _level3TwoFoodRate;
                currentThreeFoodRate = _level3ThreeFoodRate;
                currentRequiredMoney = _level4RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 4:
                currentOneFoodRate = _level4OneFoodRate;
                currentTwoFoodRate = _level4TwoFoodRate;
                currentThreeFoodRate = _level4ThreeFoodRate;
                currentRequiredMoney = _level5RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 5:
                currentOneFoodRate = _level5OneFoodRate;
                currentTwoFoodRate = _level5TwoFoodRate;
                currentThreeFoodRate = _level5ThreeFoodRate;
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
