using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodCountRateUpgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI moneyText;

    [Header("Texts")]
    public string upgradeTitle;
    public string upgradeDescription;

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
                    break;
                case 2:
                    currentLevel++;
                    currentOneFoodRate = _level3OneFoodRate;
                    currentTwoFoodRate = _level3TwoFoodRate;
                    currentThreeFoodRate = _level3ThreeFoodRate;
                    currentRequiredMoney = _level4RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    break;
                case 3:
                    currentLevel++;
                    currentOneFoodRate = _level4OneFoodRate;
                    currentTwoFoodRate = _level4TwoFoodRate;
                    currentThreeFoodRate = _level4ThreeFoodRate;
                    currentRequiredMoney = _level5RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    break;
                case 4:
                    currentLevel++;
                    currentOneFoodRate = _level5OneFoodRate;
                    currentTwoFoodRate = _level5TwoFoodRate;
                    currentThreeFoodRate = _level5ThreeFoodRate;
                    currentRequiredMoney = 0;
                    moneyText.text = "MAX";
                    break;
            }
        }
    }

    public void ResetUpgrade()
    {
        currentLevel = 1;
        currentOneFoodRate = _level1OneFoodRate;
        currentTwoFoodRate = _level1TwoFoodRate;
        currentThreeFoodRate = _level1ThreeFoodRate;
        currentRequiredMoney = _level2RequiredMoney;

        titleText.text = upgradeTitle;
        descriptionText.text = upgradeDescription;
        moneyText.text = currentRequiredMoney.ToString();
    }
}
