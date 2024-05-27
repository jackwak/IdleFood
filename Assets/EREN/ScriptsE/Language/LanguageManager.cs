using EditorAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Unity.Collections;


public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }


    [SerializeField, InlineButton(nameof(ApplyAll))] public Languages currentLanguage;
    [EditorAttributes.ReadOnly] public Languages applyedLanguage;

    [Header("All Languages SO")]
    [SerializeField] private LanguageSO enSO;
    [SerializeField] private LanguageSO trSO;
    [HideInInspector] public LanguageSO selectedSO;



    [Header("_________________________________________________________________________________________________________________________________________________________________")]

    [Header("Other")]
    [SerializeField] private TMP_Text initial;

    [Header("Map Texts")]
    [SerializeField] private TMP_Text levelTitle;
    [SerializeField] private TMP_Text level1Title;
    [SerializeField] private TMP_Text level2Title;
    [SerializeField] private TMP_Text level3Title;

    [Header("Level 1 Upgrade Texts")]
    [SerializeField] private TMP_Text upgradesTitle;
    [SerializeField] private TMP_Text customerRateUpgradeTitle;
    [SerializeField] private TMP_Text customerRateUpgradeDescription;
    [SerializeField] private TMP_Text foodCountRateUpgradeTitle;
    [SerializeField] private TMP_Text foodCountRateUpgradeDescription;
    [SerializeField] private TMP_Text foodPrepareSpeedUpgradeTitle;
    [SerializeField] private TMP_Text foodPrepareSpeedUpgradeDescription;
    [SerializeField] private TMP_Text takingOrderTimeUpgradeTitle;
    [SerializeField] private TMP_Text takingOrderTimeUpgradeDescription;
    [SerializeField] private TMP_Text addWaiterUpgradeTitle;
    [SerializeField] private TMP_Text addWaiterUpgradeDescription;


    private void Start()
    {
        ApplyAll();
    }


    public void InGameSwitchLanguageButton()
    {
        switch (applyedLanguage)
        {
            case Languages.english:
                currentLanguage = Languages.turkish;
                break;
            case Languages.turkish:
                currentLanguage = Languages.english;
                break;
        }

        ApplyAll();
    }


    void ApplyAll()
    {
        ChangeSelectedLanguage();
        ApplySelectedLanguage();
    }
    void ChangeSelectedLanguage()
    {
        switch (currentLanguage)
        {
            case Languages.english:
                selectedSO = enSO;
                applyedLanguage = Languages.english;
                break;
            case Languages.turkish:
                selectedSO = trSO;
                applyedLanguage = Languages.turkish;
                break;
        }
    }
    void ApplySelectedLanguage()
    {
        initial.text = selectedSO.initial;

        levelTitle.text = selectedSO.levelTitle + " " + GameManager.Instance.currentLevelId;
        level1Title.text = selectedSO.level1Title;
        level2Title.text = selectedSO.level2Title;
        level3Title.text = selectedSO.level3Title;

        string currentSceneName = SceneManager.GetActiveScene().name;
        switch (currentSceneName)
        {
            case "Level1":
                upgradesTitle.text = selectedSO.upgradesTitle;
                customerRateUpgradeTitle.text = selectedSO.customerRateUpgradeTitle;
                customerRateUpgradeDescription.text = selectedSO.customerRateUpgradeDescription;
                foodCountRateUpgradeTitle.text = selectedSO.foodCountRateUpgradeTitle;
                foodCountRateUpgradeDescription.text = selectedSO.foodCountRateUpgradeDescription;

                foodPrepareSpeedUpgradeTitle.text = selectedSO.foodPrepareSpeedUpgradeTitle;
                foodPrepareSpeedUpgradeDescription.text = selectedSO.foodPrepareSpeedUpgradeDescription;

                takingOrderTimeUpgradeTitle.text = selectedSO.takingOrderTimeUpgradeTitle;
                takingOrderTimeUpgradeDescription.text = selectedSO.takingOrderTimeUpgradeDescription;

                addWaiterUpgradeTitle.text = selectedSO.addWaiterUpgradeTitle;
                addWaiterUpgradeDescription.text = selectedSO.addWaiterUpgradeDescription;
                break;
            case "Level1Copy":
                upgradesTitle.text = selectedSO.upgradesTitle;
                customerRateUpgradeTitle.text = selectedSO.customerRateUpgradeTitle;
                customerRateUpgradeDescription.text = selectedSO.customerRateUpgradeDescription;
                foodCountRateUpgradeTitle.text = selectedSO.foodCountRateUpgradeTitle;
                foodCountRateUpgradeDescription.text = selectedSO.foodCountRateUpgradeDescription;

                foodPrepareSpeedUpgradeTitle.text = selectedSO.foodPrepareSpeedUpgradeTitle;
                foodPrepareSpeedUpgradeDescription.text = selectedSO.foodPrepareSpeedUpgradeDescription;

                takingOrderTimeUpgradeTitle.text = selectedSO.takingOrderTimeUpgradeTitle;
                takingOrderTimeUpgradeDescription.text = selectedSO.takingOrderTimeUpgradeDescription;

                addWaiterUpgradeTitle.text = selectedSO.addWaiterUpgradeTitle;
                addWaiterUpgradeDescription.text = selectedSO.addWaiterUpgradeDescription;
                break;
        }
    }

    public void CheckSavedLanguageInitialForLoadGame()
    {
        switch (PlayerPrefs.GetString("languageInitial"))
        {
            case "EN":
                selectedSO = enSO;
                currentLanguage = Languages.english;
                applyedLanguage = Languages.english;
                ApplyAll();
                break;
            case "TR":
                selectedSO = trSO;
                currentLanguage = Languages.turkish;
                applyedLanguage = Languages.turkish;
                ApplyAll();
                break;
        }
    }


}

public enum Languages
{
    english,
    turkish
}
