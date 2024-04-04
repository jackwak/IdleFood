using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRateUpgrade : MonoBehaviour
{
    [Header("Texts")]
    public string upgradeTitle;
    public string upgradeDescription;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Main Stats")]
    [SerializeField] public int currentLevel;
    [SerializeField] public int maxLevel = 5;
    [Space(10)]
    [SerializeField] public float currentRate;
    [SerializeField] public int currentRequiredMoney;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Level 1")]
    [Range(0,100)]
    [SerializeField] private float _level1Rate = 10f;
    [SerializeField] private int _level1RequiredMoney;

    [Header("Level 2")]
    [Range(0, 100)]
    [SerializeField] private float _level2Rate = 15f;
    [SerializeField] private int _level2RequiredMoney;

    [Header("Level 3")]
    [Range(0, 100)]
    [SerializeField] private float _level3Rate = 25f;
    [SerializeField] private int _level3RequiredMoney;

    [Header("Level 4")]
    [Range(0, 100)]
    [SerializeField] private float _level4Rate = 40f;
    [SerializeField] private int _level4RequiredMoney;

    [Header("Level 5")]
    [Range(0, 100)]
    [SerializeField] private float _level5Rate = 50f;
    [SerializeField] private int _level5RequiredMoney;

    public float MakeUpgrade()
    {
        if(currentLevel < maxLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    currentLevel++;
                    currentRate = _level2Rate;
                    currentRequiredMoney = _level3RequiredMoney;
                    return currentRate;
                case 2:
                    currentLevel++;
                    currentRate = _level3Rate;
                    currentRequiredMoney = _level4RequiredMoney;
                    return currentRate;
                case 3:
                    currentLevel++;
                    currentRate = _level4Rate;
                    currentRequiredMoney = _level5RequiredMoney;
                    return currentRate;
                case 4:
                    currentLevel++;
                    currentRate = _level5Rate;
                    //currentRequiredMoney = _level6RequiredMoney;
                    return currentRate;

            }
        }
        return currentRate;
    }

    public void ResetUpgrade()
    {
        currentRate = _level1Rate;
        currentLevel = 1;
        currentRequiredMoney = _level2RequiredMoney;
    }
}
