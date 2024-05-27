using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddWaiterUpgrade : MonoBehaviour
{
    public static AddWaiterUpgrade Instance;
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
    [SerializeField] public int maxLevel = 2;
    [Space(10)]
    [SerializeField] public float currentWaiterCount;
    [SerializeField] public float currentRequiredMoney;
    [Space(10)]
    [SerializeField] private GameObject waiterObj;
    [SerializeField] private Transform waiterSpawnPoint;
    [SerializeField] private List<GameObject> waiterBoxList;

    [Header("________________________________________________________________________________________________________________________________________________")]

    [Header("Level 1")]
    [SerializeField] private float _level1RequiredMoney;

    [Header("Level 2")]
    [SerializeField] private float _level2RequiredMoney;

    [Header("Level 3")]
    [SerializeField] private float _level3RequiredMoney;

    [Header("Level 4")]
    [SerializeField] private float _level4RequiredMoney;

    [Header("Level 5")]
    [SerializeField] private float _level5RequiredMoney;

    public void MakeUpgrade()
    {
        if (currentLevel < maxLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    waiterBoxList[currentLevel - 1].SetActive(true);
                    currentLevel++;
                    currentWaiterCount++;
                    currentRequiredMoney = _level3RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 2:
                    waiterBoxList[currentLevel - 1].SetActive(true);
                    currentLevel++;
                    currentWaiterCount++;
                    currentRequiredMoney = _level4RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 3:
                    waiterBoxList[currentLevel - 1].SetActive(true);
                    currentLevel++;
                    currentWaiterCount++;
                    currentRequiredMoney = _level5RequiredMoney;
                    moneyText.text = currentRequiredMoney.ToString();
                    levelText.text = currentLevel.ToString();
                    break;
                case 4:
                    waiterBoxList[currentLevel - 1].SetActive(true);
                    currentLevel++;
                    currentWaiterCount++;
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
    //    currentWaiterCount = 1;
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
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 1:
                currentRequiredMoney = _level2RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 2:
                //waiterBoxList[currentLevel - 2].SetActive(true);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                currentRequiredMoney = _level3RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 3:
                //waiterBoxList[currentLevel - 2].SetActive(true);
                //waiterBoxList[currentLevel - 3].SetActive(true);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                currentRequiredMoney = _level4RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 4:
                //waiterBoxList[currentLevel - 2].SetActive(true);
                //waiterBoxList[currentLevel - 3].SetActive(true);
                //waiterBoxList[currentLevel - 4].SetActive(true);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                currentRequiredMoney = _level5RequiredMoney;

                moneyText.text = currentRequiredMoney.ToString();
                levelText.text = currentLevel.ToString();
                break;
            case 5:
                //waiterBoxList[currentLevel - 2].SetActive(true);
                //waiterBoxList[currentLevel - 3].SetActive(true);
                //waiterBoxList[currentLevel - 4].SetActive(true);
                //waiterBoxList[currentLevel - 5].SetActive(true);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
                Instantiate(waiterObj, waiterSpawnPoint.position, Quaternion.identity);
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
