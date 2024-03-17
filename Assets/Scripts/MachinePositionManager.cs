using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePositionManager : MonoBehaviour
{
    public static MachinePositionManager Instance;

    [Header("References")]
    public List<Transform> MachinePosition = new List<Transform>();

    [Header("Variables")]
    private Waiter[] _waiters;

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

    public Transform GetAvaibleMachinePosition(Waiter waiter)
    {
        int machinePositionCount = MachinePosition.Count;

        for (int i = 0; i < machinePositionCount; i++)
        {
            if (_waiters[i] == null)
            {
                _waiters[i] = waiter;
                return MachinePosition[i];
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
