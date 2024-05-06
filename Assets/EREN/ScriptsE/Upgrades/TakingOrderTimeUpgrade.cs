using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakingOrderTimeUpgrade : MonoBehaviour
{
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
    [SerializeField] public float currentTakingOrderTime;
    [SerializeField] public float currentRequiredMoney;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Level 1")]
    [SerializeField, Range(0, 10)] private float _level1TakingOrderTime;
    [SerializeField] private float _level1RequiredMoney;

    [Header("Level 2")]
    [SerializeField, Range(0, 10)] private float _level2TakingOrderTime;
    [SerializeField] private float _level2RequiredMoney;

    [Header("Level 3")]
    [SerializeField, Range(0, 10)] private float _level3TakingOrderTime;
    [SerializeField] private float _level3RequiredMoney;

    [Header("Level 4")]
    [SerializeField, Range(0, 10)] private float _level4TakingOrderTime;
    [SerializeField] private float _level4RequiredMoney;

    [Header("Level 5")]
    [SerializeField, Range(0, 10)] private float _level5TakingOrderTime;
    [SerializeField] private float _level5RequiredMoney;

    public void MakeUpgrade()
    {
        if (currentLevel < maxLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    currentLevel++;
                    currentTakingOrderTime = _level2TakingOrderTime;
                    currentRequiredMoney = _level3RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 2:
                    currentLevel++;
                    currentTakingOrderTime = _level3TakingOrderTime;
                    currentRequiredMoney = _level4RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 3:
                    currentLevel++;
                    currentTakingOrderTime = _level4TakingOrderTime;
                    currentRequiredMoney = _level5RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 4:
                    currentLevel++;
                    currentTakingOrderTime = _level5TakingOrderTime;
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

    public void ResetUpgrade()
    {
        currentLevel = 1;
        currentTakingOrderTime = _level1TakingOrderTime;
        currentRequiredMoney = _level2RequiredMoney;

        //titleText.text = upgradeTitle;
        //descriptionText.text = upgradeDescription;
        moneyText.text = currentRequiredMoney.ToString();
        levelText.text = currentLevel.ToString();
    }
}
