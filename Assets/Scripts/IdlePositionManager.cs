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

    public Waiter[] Waiters;

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

    public Transform GetAvaibleIdlePosition(Waiter waiter)
    {
        int idlePositionCount = IdlePositions.Count;

        for (int i = 0; i < idlePositionCount; i++)
        {
            if (Waiters[i] == null)
            {
                Waiters[i] = waiter;
                return IdlePositions[i];
            }
        }

        return null;
    }

    public void RemoveWaiterFromIdlePosition(Waiter waiter)
    {
        int indexOfWaiter = Array.IndexOf(Waiters, waiter);

        Waiters[indexOfWaiter] = null;
    }
}