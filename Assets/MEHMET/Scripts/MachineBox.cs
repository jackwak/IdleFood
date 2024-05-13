using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBox : MonoBehaviour
{
    [SerializeField] private GameObject _secondMachineGO;
    [SerializeField] private MachinePositionManager _machinePositionManager;


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

                //spawn new machine
                _secondMachineGO.SetActive(true);
                _machinePositionManager.AddMachine(_secondMachineGO.GetComponent<Machine>());
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }
}
