using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdlePositionManager : MonoBehaviour
{
    public static IdlePositionManager Instance;

    [Header("References")]
    public List<Transform> IdlePositions = new List<Transform>();

    [Header("Variables")]
    [SerializeField] private Waiter[] _waiters;

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

        _waiters = new Waiter[IdlePositions.Count];
    }

    public Transform GetAvaibleIdlePosition(Waiter waiter)
    {
        int idlePositionCount = IdlePositions.Count;

        for (int i = 0; i < idlePositionCount; i++)
        {
            if (_waiters[i] == null)
            {
                _waiters[i] = waiter;
                return IdlePositions[i];
            }
        }

        return null;
    }

    public void RemoveWaiterFromIdlePosition(Waiter waiter)
    {
        int indexOfWaiter = Array.IndexOf(_waiters, waiter);

        if (_waiters[indexOfWaiter] != null)
        {
            _waiters[indexOfWaiter] = null;
        }
    }
}