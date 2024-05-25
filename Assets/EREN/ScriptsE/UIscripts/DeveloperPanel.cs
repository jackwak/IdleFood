using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DeveloperPanel : MonoBehaviour
{
    bool IsMenuOpen;
    CustomerManager customerManager;
    SpawnerManager spawnerManager;

    private void Awake()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }


        IsMenuOpen = false;
        customerManager = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
        spawnerManager = GameObject.FindGameObjectWithTag("SpawnerManager").GetComponent<SpawnerManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            OpenDeveloperMenu();
        }

        if (startTimer)
        {
            moneyAmountEnd = MoneyManager.Instance.playerMoney;
            timer += Time.deltaTime;
            MoneyAvarageCalculator();
            resultText.GetComponent<TextMeshProUGUI>().text = "Result: \n " + moneyPerSecond.ToString("F2") + " money/s";
        }
    }


    public void OpenDeveloperMenu()
    {
        if (!IsMenuOpen)
        {
            IsMenuOpen = true;
            this.GetComponent<Image>().enabled = true;
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }

            //customerManager.specialForDevMode = true;   //GARSONLAR EKLENÝNCE KALDIR
        }
        else
        {
            IsMenuOpen = false;
            this.GetComponent<Image>().enabled = false;
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            //customerManager.specialForDevMode = false;   //GARSONLAR EKLENÝNCE KALDIR

        }
    }

    public void ToggleSpawn()
    {
        if (spawnerManager.spawnlamaBaslasinMi)
        {
            spawnerManager.spawnlamaBaslasinMi = false;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (!spawnerManager.spawnlamaBaslasinMi)
        {
            spawnerManager.spawnlamaBaslasinMi = true;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
        }
    }
    public void KillAllNpc()
    {
        spawnerManager.TumNpcleriOldurForDevPanel();
    }
    public void SiradakiMusterininIsteginiBirArttir()
    {
        customerManager.siparisVermeSirasi[0].GetComponent<Customer>().MusteriyeYemekVer();
    }




    [Header("Avarage Money")]
    public float timer = 0;
    private bool startTimer = false;
    public GameObject resultText;
    [TextArea] public List<string> avarageMoneyRecord;

    private float moneyAmountStart;
    private float moneyAmountEnd;

    private float moneyPerMinute;
    private float moneyPerSecond;

    public void MoneyAvarageCalculator()  //dakika ve saniye baþýna geliri gösterir.
    {
        moneyPerSecond = (moneyAmountEnd - moneyAmountStart) / timer;
        moneyPerMinute = (moneyAmountEnd - moneyAmountStart) / (timer / 60f);
    }
    public void MoneyAddRecord()
    {
        avarageMoneyRecord.Add("StartMoney: " + moneyAmountStart + " | EndMoney: " + moneyAmountEnd + " | EarnedMoney: " + (moneyAmountEnd - moneyAmountStart) + " | Time: " + timer + " \nMoneyPerSec: " + moneyPerSecond + " \nMoneyPerMin: " + moneyPerMinute);
    }
    public void MoneyTimerReset()
    {
        startTimer = false;
        timer = 0;
        resultText.GetComponent<TextMeshProUGUI>().text = "Result: \n " + "0" + " money/s";
    }
    public void MoneyTimerStart()
    {
        moneyAmountStart = MoneyManager.Instance.playerMoney;
        startTimer = true;
    }
}
