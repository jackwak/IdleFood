using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{
    [SerializeField] private int currentActiveLevel;
    [SerializeField] private Sprite whiteCloud;
    [SerializeField] private Sprite grayCloud;


    private void Start()
    {
        ChangeCurrentLevelMapPin(currentActiveLevel);
    }


    void ChangeCurrentLevelMapPin(int currentLevel)
    {
        for (int i = 0; i < this.transform.Find("Levels").gameObject.transform.childCount; i++)
        {
            this.transform.Find("Levels").gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }   //Tüm Map Pinleri Kapatýr.

        for (int i = currentLevel; i < this.transform.Find("Levels").gameObject.transform.childCount; i++)
        {
            this.transform.Find("Levels").gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = grayCloud;
        }   //Aktif olmayan levellerin bulutlarýný gri yapar.

        for (int i = currentLevel - 1; i >= 0; i--)
        {
            Debug.Log(i);
            this.gameObject.transform.Find("Levels").gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = whiteCloud;
        }   //Aktif olan levelleri beyaz bulut yapar.

        this.gameObject.transform.Find("Levels").gameObject.transform.GetChild(currentLevel - 1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        currentActiveLevel = currentLevel;
    }   //Mevcut level bilgisi verildiðinde o levelin pin'ini aktif eder. Ve bulutlarý ayarlar.

    public void MapPanelCloseButton()
    {
        this.gameObject.transform.parent.gameObject.transform.Find("SettingsPanel").gameObject.GetComponent<SettingsPanel>().CloseMenu();
        this.gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }



}
