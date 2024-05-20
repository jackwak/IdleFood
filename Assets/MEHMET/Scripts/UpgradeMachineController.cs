using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMachineController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MachineData _machineData;
    [SerializeField] private Food _food;
    [SerializeField] private GameObject _machineBoxGO;
    //[SerializeField] private GameObject _machineUpgradePanel;

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _upgradePriceText;
    [SerializeField] private TextMeshProUGUI _foodPriceText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _filledImage;
    [SerializeField] private GameObject _maxLevelImage;
    [SerializeField] private GameObject _upgradeButtonGO;

    [Header("Variables")]
    [SerializeField] private int _foodPricePercentIncrease = 4;
    [SerializeField] private int _foodLevelUpPercentIncrease = 40;
    [SerializeField] private int _upgradePricePercentIncrease = 4;
    [SerializeField] private int _upgradeLevelUpPercentIncrease = 40;
    [SerializeField] private float _maxLevelCount = 10;
    private float _levelCounter = 1;

    public void DecreaseDispenceTime(float percent)
    {
        float dispenceTime = _machineData.DispenseTime;

        float newDispenceTime = dispenceTime * (100 - percent) / 100;

        _machineData.DispenseTime = newDispenceTime;
    }

    public void LevelUpMachine()
    {
        if (_levelCounter < 50)
        {

            _levelCounter++;
            Debug.Log(_levelCounter % _maxLevelCount);

            if (_levelCounter % _maxLevelCount != 1)
            {
                //update food price
                float foodPrice = _food.Price;
                float newFoodPrice = foodPrice * (100 + _foodPricePercentIncrease) / 100;

                _food.Price = newFoodPrice;

                //update upgrade price

                float upgradePrice = _machineData.UpgradePrice;
                float newUpgradePrice = upgradePrice * (100 + _upgradePricePercentIncrease) / 100;

                _machineData.UpgradePrice = newUpgradePrice;

                //update ui
                _foodPriceText.text = newFoodPrice.ToString();
                _upgradePriceText.text = newUpgradePrice.ToString();
                float number = _levelCounter;
                if (_levelCounter > 10)
                {
                   number = _levelCounter % _maxLevelCount;
                    if (number == 0) number = 10;
                }
                _filledImage.fillAmount = number / _maxLevelCount;
                _levelText.text = _levelCounter.ToString();

                
            }
            else
            {
                if (_levelCounter == 11)
                {
                    //Show machine box
                    _machineBoxGO.SetActive(true);
                }

                float foodPrice = _food.Price;
                float newFoodPrice = foodPrice * (100 + _foodLevelUpPercentIncrease) / 100;

                _food.Price = newFoodPrice;

                //update upgrade price

                float upgradePrice = _machineData.UpgradePrice;
                float newUpgradePrice = upgradePrice * (100 + _upgradeLevelUpPercentIncrease) / 100;

                _machineData.UpgradePrice = newUpgradePrice;

                //update ui
                _foodPriceText.text = newFoodPrice.ToString();
                _upgradePriceText.text = newUpgradePrice.ToString();
                _filledImage.fillAmount = 1 / _maxLevelCount;
                _levelText.text = _levelCounter.ToString();
            }
        }
        else 
        {
            _maxLevelImage.SetActive(true);
            _upgradeButtonGO.SetActive(false);
        }
    }
}
