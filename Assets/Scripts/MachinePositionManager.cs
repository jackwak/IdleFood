using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePositionManager : MonoBehaviour
{
    public static MachinePositionManager Instance;

    [Header("References")]
    public List<Machine> Machines = new List<Machine>();

    [Header("Variables")]
    private Waiter[] _waiters;
    private bool[] _isPositionAvailable;

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

        _isPositionAvailable = new bool[Machines.Count];
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

    public void RemoveWaiterFromMachinePosition(Waiter waiter)
    {
        int indexOfWaiter = Array.IndexOf(_waiters, waiter);

        _waiters[indexOfWaiter] = null;
    }
}
