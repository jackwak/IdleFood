using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LoadGame(); 
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        #region MainSettings
        PlayerPrefs.SetFloat("playerMoney", MoneyManager.Instance.playerMoney);
        PlayerPrefs.SetInt("currentLevelId", GameManager.Instance.currentLevelId);
        #endregion

        #region SoundSettings
        int soundSettings = 0;
        if (UISounds.Instance.gameObject.activeSelf) soundSettings = 1;
        else soundSettings = 0;

        PlayerPrefs.SetInt("soundSettings", soundSettings);
        #endregion

        #region MusicSettings
        int musicSettings = 0;
        if (BackgroundMusic.Instance.gameObject.activeSelf) musicSettings = 1;
        else musicSettings = 0;

        PlayerPrefs.SetInt("musicSettings", musicSettings);
        #endregion

        #region LanguageSettings
        PlayerPrefs.SetString("languageInitial", LanguageManager.Instance.selectedSO.initial);
        #endregion

        #region UpgradeSettings
        PlayerPrefs.SetInt("customerRateUpgradeCurrentLevel", CustomerRateUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("foodCountRateUpgradeCurrentLevel", FoodCountRateUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("foodPrepareSpeedUpgradeCurrentLevel", FoodPrepareSpeedUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("takingOrderTimeUpgradeCurrentLevel", TakingOrderTimeUpgrade.Instance.currentLevel);
        PlayerPrefs.SetInt("addWaiterUpgradeCurrentLevel", AddWaiterUpgrade.Instance.currentLevel);
        #endregion
    }

    public void LoadGame()
    {    
        GameManager.Instance.currentLevelId = PlayerPrefs.GetInt("currentLevelId");
        if(GameManager.Instance.currentLevelId == 1 && SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level1");
        }
        else if(GameManager.Instance.currentLevelId == 2 && SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (GameManager.Instance.currentLevelId == 2 && SceneManager.GetActiveScene().name == "Level2")
        {

        }


        MoneyManager.Instance.playerMoney = PlayerPrefs.GetFloat("playerMoney");

        CustomerRateUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("customerRateUpgradeCurrentLevel");
        FoodCountRateUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("foodCountRateUpgradeCurrentLevel");
        FoodPrepareSpeedUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("foodPrepareSpeedUpgradeCurrentLevel");
        TakingOrderTimeUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("takingOrderTimeUpgradeCurrentLevel");
        AddWaiterUpgrade.Instance.currentLevel = PlayerPrefs.GetInt("addWaiterUpgradeCurrentLevel");

        UpgradeManager.Instance.SetAllUpgradesForStart(); //Tüm upgradelerin seviyesine göre ayarlamalarý baþlatýr.
        LanguageManager.Instance.CheckSavedLanguageInitialForLoadGame(); //En son seçilen dilde oyunu açar.
    }

    public void ResetGame()
    {
        //PlayerPrefs.SetFloat("playerMoney", 0);
        //PlayerPrefs.SetInt("currentLevelId", 1);

        //PlayerPrefs.SetInt("customerRateUpgradeCurrentLevel", 1);
        //PlayerPrefs.SetInt("foodCountRateUpgradeCurrentLevel", 1);
        //PlayerPrefs.SetInt("foodPrepareSpeedUpgradeCurrentLevel", 1);
        //PlayerPrefs.SetInt("takingOrderTimeUpgradeCurrentLevel", 1);
        //PlayerPrefs.SetInt("addWaiterUpgradeCurrentLevel", 1);


        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("currentLevelId", 1);
        LoadGame();
    }

}
