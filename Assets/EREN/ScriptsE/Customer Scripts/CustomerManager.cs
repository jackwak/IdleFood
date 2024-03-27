using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public event Action OnHasAnyCustomer;

    public int musteriOlmaSansii; //NPC'nin m��teri olma �ans�. (Y�zdesel Olarak)
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
    }   //T�m parkPointleri s�f�rlar //Ba�lang��ta �al��t�r�lmas� gerek

    public void CheckAndSendIfCustomerDone()
    {
        foreach (GameObject item in siparisVermeSirasi)
        {
            Customer customer = item.GetComponent<Customer>();
            if (customer.alinanYemekAdedi >= customer.FoodCount && customer.durumAciklamasi != "Sipari�imi Ald�")
            {
                musterilerList[customer.selectedParkPointIndex] = null;      //YEN� KOD
                siparisVermeSirasi.Remove(item);
                //customer.durumAciklamasi = "Sipari�imi Ald�m, Ayr�l�yorum";
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
