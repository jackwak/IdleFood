using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LA",menuName = "ScriptableObjects/NewLanguage")]
public class LanguageSO : ScriptableObject
{
    [Header("Other")]
    public string initial;

    [Header("Map Texts")]
    public string levelTitle;
    public string level1Title;
    public string level2Title;
    public string level3Title;

    [Header("Upgrade Texts For Level 1")]
    public string upgradesTitle;
    [Space]
    public string customerRateUpgradeTitle;
    public string customerRateUpgradeDescription;
    [Space]
    public string foodCountRateUpgradeTitle;
    public string foodCountRateUpgradeDescription;
    [Space]
    public string foodPrepareSpeedUpgradeTitle;
    public string foodPrepareSpeedUpgradeDescription;
    [Space]
    public string takingOrderTimeUpgradeTitle;
    public string takingOrderTimeUpgradeDescription;
    [Space]
    public string addWaiterUpgradeTitle;
    public string addWaiterUpgradeDescription;

}
