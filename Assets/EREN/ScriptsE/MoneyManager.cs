using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    public static MoneyManager Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(this);

        DontDestroyOnLoad(Instance);
    }


    [SerializeField] public float playerMoney;

    private void Update()
    {
        UpdateMoneyText(); //Oyunun son halinde kald�r�labilir.
    }

    public void AddMoney(float money)
    {
        playerMoney += money;
        UpdateMoneyText();
    }
    public void RemoveMoney(float money)
    {
        playerMoney -= money;
    }
    public void UpdateMoneyText()
    {
        moneyText.text = playerMoney.ToString();
    }

}
