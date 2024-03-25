using System.Collections;
using System.Collections.Generic;
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

            customerManager.specialForDevMode = true;   //GARSONLAR EKLENÝNCE KALDIR
        }
        else
        {
            IsMenuOpen = false;
            this.GetComponent<Image>().enabled = false;
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            customerManager.specialForDevMode = false;   //GARSONLAR EKLENÝNCE KALDIR

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
    public void SiradakiMusterininIsteginiBirArttýr()
    {
        customerManager.siparisVermeSirasi[0].GetComponent<Customer>().MusteriyeYemekVer();
    }
}
