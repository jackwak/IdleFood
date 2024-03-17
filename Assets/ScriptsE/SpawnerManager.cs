using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //Maximum npc sayýsý ekle (önce hareket etme ve yok olmalarýný ekle)

    [SerializeField] GameObject npcObject;
    [SerializeField] public bool varyantKonumlarAcilsinMi;
    [SerializeField] int kacSpawnNoktasiKullanilsin;
    [SerializeField] int sahnedekiMaxNpcSayisi;
    [SerializeField] float kacSaniyedeBirSpawnlansin;
    [SerializeField] public float hareketHizi;
    [SerializeField] public WalkingMethod npclerinYurumeMetodu;
    [SerializeField] bool spawnlamaBaslasinMi;
    [SerializeField] bool npcleriOldur;

    [HideInInspector] public int currentNpcObjectCount;
    public List<GameObject> npcList = new List<GameObject>();
    bool islemdeNpcVarMi;
    public enum WalkingMethod
    {
        Transform,
        NavMeshAgent,
        //AddForce,
    }
    GameObject customerManager; 


    void Start()
    {
        customerManager = GameObject.FindWithTag("CustomerManager");
        currentNpcObjectCount = 0;
        islemdeNpcVarMi = false;
    }
    void Update()
    {
        AralikliSpawnlama(kacSaniyedeBirSpawnlansin);
        TumNpcleriOldur();

        if (spawnlamaBaslasinMi && currentNpcObjectCount < sahnedekiMaxNpcSayisi) //GEREKSÝZ SÝL
        {
        }
    }

    private void SpawnNpc()
    {
        int range = UnityEngine.Random.Range(1, kacSpawnNoktasiKullanilsin + 1);
        Vector3 spawnerVector3 = new Vector3(this.gameObject.transform.GetChild(range - 1).gameObject.transform.position.x, this.gameObject.transform.GetChild(range - 1).gameObject.transform.position.y, this.gameObject.transform.GetChild(range - 1).gameObject.transform.position.z);
        Instantiate(npcObject, spawnerVector3, Quaternion.identity);
        currentNpcObjectCount = currentNpcObjectCount + 1;
    }
    public void AralikliSpawnlama(float x)
    {
        if (spawnlamaBaslasinMi && currentNpcObjectCount < sahnedekiMaxNpcSayisi)
        {
            StartCoroutine(AralikliSpawnlamaIE(x));
        }
    }
    IEnumerator AralikliSpawnlamaIE(float x)
    {
        if (islemdeNpcVarMi == false)
        {
            islemdeNpcVarMi = true;
            yield return new WaitForSeconds(x);
            SpawnNpc();
            islemdeNpcVarMi = false;
        }


    }

    void TumNpcleriOldur()
    {
        if(npcleriOldur == true)
        {
            foreach (var npc in npcList)
            {
                Destroy(npc);
            }
            npcList.Clear();
            currentNpcObjectCount = 0;
            npcleriOldur = false;
            customerManager.GetComponent<CustomerManager>().ParkPointResetAndRebuild();
        }

    }





}
