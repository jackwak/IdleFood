using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaiterBox : MonoBehaviour
{
    [SerializeField] private GameObject _waiterGO;
    [SerializeField] private Transform _waiterSpawnPosition;

    private void OnEnable()
    {
        InputManager.OnStartTouch += CheckWaiterBox;
    }
    private void OnDisable()
    {
        InputManager.OnStartTouch -= CheckWaiterBox;
    }

    private void CheckWaiterBox(Vector2 vector2)
    {
        // Dokunulan noktayý 3D uzayda bir ýþýn haline getir
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Iþýn bir nesneye çarparsa
        if (Physics.Raycast(ray, out hit))
        {
            // Çarpýlan nesneyi kontrol et

            GameObject touchedObject = hit.transform.gameObject;
            if (touchedObject.name != "Waiter Box") return;

            Debug.Log("Touched object: " + touchedObject.name);
            // Burada dokunulan nesneyle ilgili yapýlacak iþlemleri gerçekleþtirin

            Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
