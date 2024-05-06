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

    [SerializeField, InlineButton(nameof(ApplyAll))] public Languages currentLanguage;
    [EditorAttributes.ReadOnly] public Languages applyedLanguage;

    [Header("All Languages SO")]
    [SerializeField] private LanguageSO enSO;
    [SerializeField] private LanguageSO trSO;
    [HideInInspector] private LanguageSO selectedSO;

    [Header("_________________________________________________________________________________________________________________________________________________________________")]

    [Header("Map Texts")]
    [SerializeField] private TMP_Text level1Title;
    [SerializeField] private TMP_Text level2Title;
    [SerializeField] private TMP_Text level3Title;

    [Header("Level 1 Upgrade Texts")]
    [SerializeField] private TMP_Text upgradesTitle;
    [SerializeField] private TMP_Text customerRateUpgradeTitle;
    [SerializeField] private TMP_Text customerRateUpgradeDescription;
    [SerializeField] private TMP_Text foodCountRateUpgradeTitle;
    [SerializeField] private TMP_Text foodCountRateUpgradeDescription;

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
                break;
            case "Level2":
                break;
        }
    }


}

public enum Languages
{
    english,
    turkish
}
