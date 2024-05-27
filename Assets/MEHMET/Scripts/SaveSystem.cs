using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    //Machines
    public List<MachinePositionManager> MachinePositionManager;

    //Path
    private static string SavePath => Application.persistentDataPath + "/gamedata.json";

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (MachinePositionManager manager in MachinePositionManager)
        {
            if (!PlayerPrefs.HasKey(manager.MachineName + "MachineCount"))
            {
                PlayerPrefs.SetInt(manager.MachineName + "MachineCount", 0);
            }
        }

        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public static void SaveUpgradeMachineControllerData(MachineData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        Debug.Log("Game data saved to " + SavePath);
    }

    public static void LoadUpgradeMachineControllerData(MachineData data)
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            JsonUtility.FromJsonOverwrite(json, data);
            Debug.Log("Game data loaded from " + SavePath);
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }

    public void SaveGame()
    {
        SaveMachineCount();
    }

    public void LoadGame()
    {
        LoadMachines();
    }

    public void ResetGame()
    {

    }

    public void SaveMachineCount()
    {

        foreach (var machine in MachinePositionManager)
        {
            int machineCount = 0;

            // kaç tane makine var
            foreach (var item in machine.Machines)
            {
                machineCount++;
            }

            PlayerPrefs.SetInt(machine.MachineName + "MachineCount", machineCount);
        }


    }

    public void LoadMachines()
    {
        foreach (var machine in MachinePositionManager)
        {
            int machineCount = PlayerPrefs.GetInt(machine.MachineName + "MachineCount");

            // load machines
            SpawnNewMachine(machine, machineCount);
        }
    }

    public void SpawnNewMachine(MachinePositionManager machine, int machineCount)
    {
        List<GameObject> lemonadeObjects = FindObjectsStartingWith(machine.MachineName + " Maker");

        Debug.Log(machineCount);
        Debug.Log(lemonadeObjects.Count);

        for (int i = 0; i < machineCount && i < lemonadeObjects.Count; i++)
        {
            lemonadeObjects[i].SetActive(true);
            machine.AddMachine(lemonadeObjects[i].GetComponent<Machine>());
            lemonadeObjects[i].GetComponent<Machine>().IsUseable = true;
        }
    }

    List<GameObject> FindObjectsStartingWith(string prefix)
    {
        List<GameObject> matchedObjects = new List<GameObject>();
        Transform[] allTransforms = Resources.FindObjectsOfTypeAll<Transform>();

        foreach (Transform t in allTransforms)
        {
            if (t.hideFlags == HideFlags.None && t.gameObject.name.StartsWith(prefix))
            {
                matchedObjects.Add(t.gameObject);
            }
        }

        return matchedObjects;
    }
}
