using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRateUpgrade : MonoBehaviour
{
    [Header("Rate")]
    [SerializeField] public float _startRate = 10f;
    [SerializeField] private float _currentRate;

    [Header("Level")]
    [SerializeField] private int _startLevel = 1;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _maxLevel = 10;

    [Header("Multiply")]
    [SerializeField] private float _multiplyRate = 1.2f;

    [Header("Money")]
    [SerializeField] public int currentWantedMoney;
    [SerializeField] private int _level2Money;
    [SerializeField] private int _level3Money;
    [SerializeField] private int _level4Money;
    [SerializeField] private int _level5Money;
    [SerializeField] private int _level6Money;
    [SerializeField] private int _level7Money;
    [SerializeField] private int _level8Money;
    [SerializeField] private int _level9Money;
    [SerializeField] private int _level10Money;

    public float MakeUpgrade()
    {
        if(_currentLevel < _maxLevel)
        {
            switch (_currentLevel)
            {
                case 1:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level3Money;
                    return _currentRate;
                case 2:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level4Money;
                    return _currentRate;
                case 3:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level5Money;
                    return _currentRate;
                case 4:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level6Money;
                    return _currentRate;
                case 5:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level7Money;
                    return _currentRate;
                case 6:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level8Money;
                    return _currentRate;
                case 7:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level9Money;
                    return _currentRate;
                case 8:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    currentWantedMoney = _level10Money;
                    return _currentRate;
                case 9:
                    _currentLevel++;
                    _currentRate *= _multiplyRate;
                    return _currentRate;
            }
        }
        return _currentRate;
    }

    public void ResetUpgrade()
    {
        _currentRate = _startRate;
        _currentLevel = _startLevel;
        currentWantedMoney = _level2Money;
    }
}
