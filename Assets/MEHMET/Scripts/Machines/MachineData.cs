using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Machine Data",fileName = "MachineData_Name")]
public class MachineData : ScriptableObject
{
    [Header("Prefabs")]
    public GameObject FoodPrefabb;

    [Header("Settings")]
    public float DispenseTime;
    public float UpgradePrice;
    public float FoodPrice;
}
