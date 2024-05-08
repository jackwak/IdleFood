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
            // Dokunulan noktayý 3D uzayda bir ýþýn haline getir
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Iþýn bir nesneye çarparsa
            if (Physics.Raycast(ray, out hit))
            {
                // Çarpýlan nesneyi kontrol et
                GameObject touchedObject = hit.transform.gameObject;
                Debug.Log("Touched object: " + touchedObject.name);
                // Burada dokunulan nesneyle ilgili yapýlacak iþlemleri gerçekleþtirin

                Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }

        //TOUCH ÇALIÞTIÐINDA BURAYI AKTÝF ET
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Dokunulan noktayý al
            Vector3 touchPosition = Input.GetTouch(0).position;

            // Dokunulan noktayý 3D uzayda bir ýþýn haline getir
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            // Iþýn bir nesneye çarparsa
            if (Physics.Raycast(ray, out hit))
            {
                // Çarpýlan nesneyi kontrol et
                GameObject touchedObject = hit.transform.gameObject;
                Debug.Log("Touched object: " + touchedObject.name);
                // Burada dokunulan nesneyle ilgili yapýlacak iþlemleri gerçekleþtirin

                Instantiate(_waiterGO, _waiterSpawnPosition.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }*/
    }
}
