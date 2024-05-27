using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBox : MonoBehaviour
{
    [SerializeField] private GameObject _secondMachineGO;
    [SerializeField] private MachinePositionManager _machinePositionManager;

    private void OnEnable()
    {
        InputManager.OnStartTouch += CheckMachineBox;
    }
    private void OnDisable()
    {
        InputManager.OnStartTouch -= CheckMachineBox;
    }

    private void CheckMachineBox(Vector2 vector2)
    {
        // Dokunulan noktayý 3D uzayda bir ýþýn haline getir
        Ray ray = Camera.main.ScreenPointToRay(vector2);
        RaycastHit hit;

        // Iþýn bir nesneye çarparsa
        if (Physics.Raycast(ray, out hit))
        {
            GameObject touchedObject = hit.transform.gameObject;

            if (touchedObject.name != "Machine Box") return;
            // Çarpýlan nesneyi kontrol et
            Debug.Log("Touched object: " + touchedObject.name);
            // Burada dokunulan nesneyle ilgili yapýlacak iþlemleri gerçekleþtirin

            //spawn new machine
            SpawnNewMachine();
        }
    }

    public void SpawnNewMachine()
    {
        _secondMachineGO.SetActive(true);
        _machinePositionManager.AddMachine(_secondMachineGO.GetComponent<Machine>());
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
