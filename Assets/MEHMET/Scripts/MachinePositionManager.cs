using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePositionManager : MonoBehaviour
{
    [Header("References")]
    public List<Machine> Machines = new List<Machine>();

    [Header("Variables")]
    private Waiter[] _waiters;
    private bool[] _isPositionAvailable;

    private void Awake()
    {
        SetMachinePositions();
        InitializeMachines();
    }

    public void InitializeMachines()
    {
        for (int i = 0; i < _isPositionAvailable.Length; i++)
        {
            _isPositionAvailable[i] = true;
        }
    }

    public bool CheckAvaibleMachine()
    {
        int machinePositionCount = Machines.Count;

        for (int i = 0; i < machinePositionCount; i++)
        {
            if (_isPositionAvailable[i])
            {
                return true;
            }
        }

        return false;
    }

    public Machine GetAvaibleMachine()
    {
        int machinePositionCount = Machines.Count;

        for (int i = 0; i < machinePositionCount; i++)
        {
            if (_isPositionAvailable[i])
            {
                _isPositionAvailable[i] = false;

                return Machines[i];
            }
        }

        return null;
    }

    public void SetMachineToAvailable(Machine machine)
    {
        int index = Machines.IndexOf(machine);

        _isPositionAvailable[index] = true;
    }

    public void SetMachinePositions()
    {
        _isPositionAvailable = new bool[Machines.Count];
    }

    public void AddMachine(Machine machine)
    {
        Machines.Add(machine);

        // Yeni elemaný eklemek için dizinin boyutunu bir artýrarak geçici bir dizi oluþturun
        bool[] geciciDizi = new bool[_isPositionAvailable.Length + 1];

        // Eski elemanlarý geçici diziye kopyalayýn
        for (int i = 0; i < _isPositionAvailable.Length; i++)
        {
            geciciDizi[i] = _isPositionAvailable[i];
        }

        // Yeni elemaný ekleyin
        geciciDizi[geciciDizi.Length - 1] = true;

        // Geçici diziyi orijinal diziye atayýn
        _isPositionAvailable = geciciDizi;
    }
}
