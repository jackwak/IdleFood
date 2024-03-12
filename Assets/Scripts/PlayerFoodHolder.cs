using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFoodHolder : MonoBehaviour
{
    private GameObject currentFoodGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            currentFoodGO = other.GetComponent<Machine>().PrepareFood();

            currentFoodGO.transform.position = Vector3.zero;
        }
    }
}

