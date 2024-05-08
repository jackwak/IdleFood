using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaiterBox : MonoBehaviour
{
    [SerializeField] private GameObject _waiterGO;
    [SerializeField] private Transform _waiterSpawnPosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Dokunulan noktay� 3D uzayda bir ���n haline getir
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // I��n bir nesneye �arparsa
            if (Physics.Raycast(ray, out hit))
            {
                // �arp�lan nesneyi kontrol et
                GameObject touchedObject = hit.transform.gameObject;
                Debug.Log("Touched object: " + touchedObject.name);
                // Burada dokunulan nesneyle ilgili yap�lacak i�lemleri ger�ekle�tirin

                Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }

        //TOUCH �ALI�TI�INDA BURAYI AKT�F ET
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Dokunulan noktay� al
            Vector3 touchPosition = Input.GetTouch(0).position;

            // Dokunulan noktay� 3D uzayda bir ���n haline getir
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            // I��n bir nesneye �arparsa
            if (Physics.Raycast(ray, out hit))
            {
                // �arp�lan nesneyi kontrol et
                GameObject touchedObject = hit.transform.gameObject;
                Debug.Log("Touched object: " + touchedObject.name);
                // Burada dokunulan nesneyle ilgili yap�lacak i�lemleri ger�ekle�tirin

                Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }*/
    }
}
