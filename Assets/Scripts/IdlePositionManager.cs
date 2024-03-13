using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdlePositionManager : MonoBehaviour
{
    public static List<Transform> IdlePositions;

    public static Transform GetAvaibleIdlePosition(Transform waiterTransform)
    {
        for (int i = 0; i < IdlePositions.Count; i++)
        {
            Transform idlePosition = IdlePositions[i];

            if (IdlePositions == null)
            {
                IdlePositions[i] = waiterTransform;
                return idlePosition;
            } 
        }

        return null;
    }

    public static void RemoveWaiterFromIdlePosition(Transform waiterTransfom)
    {
        IdlePositions.Remove(waiterTransfom);
    }
}
