using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMachineController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MachinePositionManager _machinePositionManager;
    [SerializeField] private MachineData _machineData;
    [SerializeField] private Food _food;
    [SerializeField] private GameObject _secondMachineGO;
    //[SerializeField] private GameObject _machineUpgradePanel;

    [Header("Variables")]
    [SerializeField] private int _foodPricePercentIncrease = 4;
    [SerializeField] private int _foodLevelUpPercentIncrease = 40;
    [SerializeField] private int _upgradePricePercentIncrease = 4;
    [SerializeField] private int _upgradeLevelUpPercentIncrease = 40;
    [SerializeField] private int _maxLevelCount = 10;
    private int _levelCount = 0;

    public float MachineData_UpgradePriceProp { get { return _machineData.UpgradePrice; } }

    public void DecreaseDispenceTime(float percent)
    {
        float dispenceTime = _machineData.DispenseTime;

        float newDispenceTime = dispenceTime * (100 - percent) / 100;

        _machineData.DispenseTime = newDispenceTime;
    }

    public void LevelUpMachine()
    {
        if (_levelCount > 50) return;

        _levelCount++;
        if (_maxLevelCount % _levelCount != 0)
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
        }
        else
        {
            if (_levelCount == 10) // bu ife gerek olmayabilir
            {
                //spawn new machine
                _secondMachineGO.SetActive(true);
                _machinePositionManager.AddMachine(_secondMachineGO.GetComponent<Machine>());
            }

            float foodPrice = _food.Price;
            float newFoodPrice = foodPrice * (100 + _foodLevelUpPercentIncrease) / 100;

            _food.Price = newFoodPrice;

            //update upgrade price

            float upgradePrice = _machineData.UpgradePrice;
            float newUpgradePrice = upgradePrice * (100 + _upgradeLevelUpPercentIncrease) / 100;

            _machineData.UpgradePrice = newUpgradePrice;

            //update ui
        }
    }
}
