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
        // Dokunulan noktay� 3D uzayda bir ���n haline getir
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // I��n bir nesneye �arparsa
        if (Physics.Raycast(ray, out hit))
        {
            // �arp�lan nesneyi kontrol et

            GameObject touchedObject = hit.transform.gameObject;
            if (touchedObject.name != "Waiter Box") return;

            Debug.Log("Touched object: " + touchedObject.name);
            // Burada dokunulan nesneyle ilgili yap�lacak i�lemleri ger�ekle�tirin

            Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
