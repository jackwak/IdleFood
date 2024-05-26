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
        // Dokunulan noktay� 3D uzayda bir ���n haline getir
        Ray ray = Camera.main.ScreenPointToRay(vector2);
        RaycastHit hit;

        // I��n bir nesneye �arparsa
        if (Physics.Raycast(ray, out hit))
        {
            GameObject touchedObject = hit.transform.gameObject;

            if (touchedObject.name != "Machine Box") return;
            // �arp�lan nesneyi kontrol et
            Debug.Log("Touched object: " + touchedObject.name);
            // Burada dokunulan nesneyle ilgili yap�lacak i�lemleri ger�ekle�tirin

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
