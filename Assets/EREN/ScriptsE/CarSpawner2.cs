using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner2 : MonoBehaviour
{
    [SerializeField] private Vector3 carRot;
    [SerializeField] private GameObject carsParentObj;
    [SerializeField] private List<GameObject> carsObj;
    [SerializeField] private List<Transform> spawnPoints;
    int choosenPoint;



    private void Start()
    {
        StartCoroutine(SpawnCarsIE());
    }

    void ChooseSpawnPoint()
    {
        choosenPoint = Random.Range(0, spawnPoints.Count);
    }

    void SpawnOnSpawnPoint()
    {
        GameObject spawnedCar = Instantiate(carsObj[Random.Range(0, carsObj.Count)], spawnPoints[choosenPoint].position, Quaternion.Euler(0,0,0));
        spawnedCar.transform.parent = carsParentObj.transform;
        spawnedCar.transform.eulerAngles = new Vector3(-90,90,0);
    }

    IEnumerator SpawnCarsIE()
    {
        yield return new WaitForSeconds(Random.Range(2f,3.5f));
        ChooseSpawnPoint();
        SpawnOnSpawnPoint();
        StartCoroutine(SpawnCarsIE());
    }

}
