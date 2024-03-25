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
        Transform levelsTransform = this.gameObject.transform.Find("ScrollArea").GetChild(0).gameObject.transform;

        for (int i = 0; i < levelsTransform.childCount; i++)
        {
            levelsTransform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }   //Tüm Map Pinleri Kapatýr.

        for (int i = currentLevel; i < levelsTransform.childCount; i++)
        {
            levelsTransform.GetChild(i).gameObject.GetComponent<Image>().sprite = grayCloud;
        }   //Aktif olmayan levellerin bulutlarýný gri yapar.

        for (int i = currentLevel - 1; i >= 0; i--)
        {
            levelsTransform.GetChild(i).gameObject.GetComponent<Image>().sprite = whiteCloud;
        }   //Aktif olan levelleri beyaz bulut yapar.

        levelsTransform.GetChild(currentLevel - 1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        currentActiveLevel = currentLevel;
    }   //Mevcut level bilgisi verildiðinde o levelin pin'ini aktif eder. Ve bulutlarý ayarlar.

    public void MapPanelCloseButton()
    {
        this.gameObject.transform.parent.gameObject.transform.Find("SettingsPanel").gameObject.GetComponent<SettingsPanel>().CloseMenu();
        this.gameObject.transform.parent.gameObject.transform.Find("MainPanel").gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }



}
