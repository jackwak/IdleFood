using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCountRateUpgrade : MonoBehaviour
{
    [Header("Start Rates")]
    [SerializeField] private int _startOneFoodRate = 20;
    [SerializeField] private int _startTwoFoodRate = 8;
    [SerializeField] private int _startThreeFoodRate = 1;

    [Header("Current Rates")]
    [SerializeField] private int _currentOneFoodRate;
    [SerializeField] private int _currentTwoFoodRate;
    [SerializeField] private int _currentThreeFoodRate;

    [Header("Level")]
    [SerializeField] private int _startLevel = 1;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _maxLevel = 10;


    public void MakeUpgrade()
    {
        if(_currentLevel < _maxLevel)
        {
            switch (_currentLevel)
            {
                case 1:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 8;
                    _currentThreeFoodRate = 1;
                    break;
                case 2:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 10;
                    _currentThreeFoodRate = 2;
                    break;
                case 3:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 11;
                    _currentThreeFoodRate = 3;
                    break;
                case 4:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 12;
                    _currentThreeFoodRate = 4;
                    break;
                case 5:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 13;
                    _currentThreeFoodRate = 6;
                    break;
                case 6:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 14;
                    _currentThreeFoodRate = 8;
                    break;
                case 7:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 15;
                    _currentThreeFoodRate = 10;
                    break;
                case 8:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 16;
                    _currentThreeFoodRate = 12;
                    break;
                case 9:
                    _currentLevel++;
                    _currentOneFoodRate = 20;
                    _currentTwoFoodRate = 18;
                    _currentThreeFoodRate = 15;
                    break;
            }
        }
    }

    public int OneFood()
    {
        return _currentOneFoodRate;
    }
    public int TwoFood()
    {
        return _currentTwoFoodRate;
    }
    public int ThreeFood()
    {
        return _currentThreeFoodRate;
    }

    public void ResetUpgrade()
    {
        _currentLevel = _startLevel;
        _currentOneFoodRate = _startOneFoodRate;
        _currentTwoFoodRate = _startTwoFoodRate;
        _currentThreeFoodRate = _startThreeFoodRate;
    }
}
