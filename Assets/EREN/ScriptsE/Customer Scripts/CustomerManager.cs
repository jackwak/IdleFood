using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public event Action OnHasAnyCustomer;

    public int musteriOlmaSansii; //NPC'nin müþteri olma þansý. (Yüzdesel Olarak)
    public BakilacakYon bakilacakYon;
    public int sahnedeKacAdetParkPointVar;
    public int birYemekSansi;
    public int ikiYemekSansi;
    public int ucYemekSansi;
    public bool HasAnyCustomer;

    public bool[] parkPointsBusy;
    public List<GameObject> musterilerList = new List<GameObject>();
    public List<GameObject> siparisVermeSirasi = new List<GameObject>();

    public bool specialForDevMode;


    public enum BakilacakYon
    {
        artiX,
        eksiX,
        artiZ,
        eksiZ,
    }


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ParkPointResetAndRebuild();
    }

    private void Update()
    {
        if (siparisVermeSirasi.Count > 0)
        {
            OnHasAnyCustomer.Invoke();
            HasAnyCustomer = true;
        }
        else
        {
            HasAnyCustomer = false;
        }
    }

    public void ParkPointResetAndRebuild()
    {
        musterilerList.Clear();
        siparisVermeSirasi.Clear();

        for (int i = 0; i < sahnedeKacAdetParkPointVar; i++)
        {
            musterilerList.Add(null);
        }

        parkPointsBusy = new bool[sahnedeKacAdetParkPointVar];
        for (int i = 0; i < parkPointsBusy.Length; i++)
        {
            parkPointsBusy[i] = false;
        }
    }   //Tüm parkPointleri sýfýrlar //Baþlangýçta çalýþtýrýlmasý gerek

    public void CheckAndSendIfCustomerDone()
    {
        foreach (GameObject item in siparisVermeSirasi)
        {
            Customer customer = item.GetComponent<Customer>();
            if (customer.alinanYemekAdedi >= customer.FoodCount && customer.durumAciklamasi != "Sipariþimi Aldý")
            {
                musterilerList[customer.selectedParkPointIndex] = null;      //YENÝ KOD
                siparisVermeSirasi.Remove(item);
                //customer.durumAciklamasi = "Sipariþimi Aldým, Ayrýlýyorum";
                //customer.hedefeVardim = false;
                parkPointsBusy[customer.selectedParkPointIndex] = false;
                //customer.selectedParkPoint = null;
                //customer.selectedWaiterPoint = null;
                //customer.buNpcMusteriMi = false;
                //item.GetComponent<Npc>().buNpcMusteriMi = false;

                Vector3 goBackVector3 = new Vector3(0, 0, 0);

                switch (item.GetComponent<Npc>().directionToGo)
                {
                    case "+x":
                        goBackVector3 = new Vector3(customer.musteriOlunanKonum.x + 60, customer.musteriOlunanKonum.y, customer.musteriOlunanKonum.z);
                        break;
                    case "-x":
                        goBackVector3 = new Vector3(customer.musteriOlunanKonum.x - 60, customer.musteriOlunanKonum.y, customer.musteriOlunanKonum.z);
                        break;
                    case "+z":
                        goBackVector3 = new Vector3(customer.musteriOlunanKonum.x, customer.musteriOlunanKonum.y, customer.musteriOlunanKonum.z + 60);
                        break;
                    case "-z":
                        goBackVector3 = new Vector3(customer.musteriOlunanKonum.x, customer.musteriOlunanKonum.y, customer.musteriOlunanKonum.z - 60);
                        break;
                    default:
                        break;
                }
                item.GetComponent<NavMeshAgent>().SetDestination(goBackVector3);
                
                break;
            }
        }
    }








}
