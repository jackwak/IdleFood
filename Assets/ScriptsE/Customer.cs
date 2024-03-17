using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Customer : MonoBehaviour
{
    Npc npcScript;
    CustomerManager customerManager;
    NavMeshAgent navMeshAgent;

    [SerializeField] public int musteriOlmaSansi;
    [SerializeField] bool buNpcMusteriMi;
    [SerializeField] GameObject selectedParkPoint;
    [SerializeField] int selectedParkPointIndex;
    [SerializeField] int istenenYemekAdedi; //Müþterinin istediði yemek adedi. (1,2,3)
    [SerializeField] int alinanYemekAdedi;  //Sipariþ verdiði yemeklerden kaç tanesini aldý?
    [SerializeField] string istenenYemek;

    [SerializeField] bool hedefeVardim;
    [SerializeField] string durumAciklamasi;
    //Ben Düz NPC'yim
    //Ben Müþteri Olamadým
    //Stand Önüne Doðru Gidiyorum
    //Stand Önündeyim
    //Sipariþ Verdim
    //Sipariþimi Aldým, Ayrýlýyorum

    [SerializeField] bool siparisTamamlandiMi;
    Vector3 musteriOlunanKonum;

    [SerializeField] bool alinanYemegiBirArttýrSadeceDevMod;    //TEST AMAÇLI KULLANILIR. TAM SÜRÜMDE SÝLÝNEBÝLÝR.

    private void Awake()
    {
        npcScript = this.gameObject.GetComponent<Npc>();
        musteriOlmaSansi = 0;
        buNpcMusteriMi = false;
        selectedParkPointIndex = -1;
        durumAciklamasi = "Ben Düz NPC'yim";
    }

    void Update()
    {
        RunWhenYouArrive(); //stand önüne varýnca çalýþýr

        SuEkseneDogruBak(); //stand önüne vardýktan sonra çalýþýr

        if(alinanYemegiBirArttýrSadeceDevMod == true)
        {
            alinanYemegiBirArttýrSadeceDevMod = false;
            YemegiAl();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BecomeCustomerArea" && buNpcMusteriMi == false && durumAciklamasi == "Ben Düz NPC'yim")
        {
            customerManager = other.gameObject.transform.parent.GetComponent<CustomerManager>();
            musteriOlmaSansi = customerManager.musteriOlmaSansii;
            ChooseCustomerOrNot();
        }
    }




    private void ChooseCustomerOrNot()
    {
        for (int i = 0; i < customerManager.parkPointsBusy.Length; i++)
        {
            if (customerManager.parkPointsBusy[i] == false)
            {
                int range = UnityEngine.Random.Range(1, 101);

                if (range <= musteriOlmaSansi)
                {
                    selectedParkPointIndex = i;
                    RunWhenYouBecomeCustomer();
                }
                else
                {
                    npcScript.buNpcMusteriMi = false;
                    buNpcMusteriMi = false;
                    durumAciklamasi = "Ben Müþteri Olamadým";
                }
                break;
            }
        }
    }   //NPC'nin müþteri olup olmadýðýný, þansa baðlý ayarlar.
    private void RunWhenYouBecomeCustomer()
    {
        this.gameObject.name = "Musteri " + selectedParkPointIndex;                             //YENÝ KOD
        customerManager.parkPointsBusy[selectedParkPointIndex] = true;
        selectedParkPoint = customerManager.gameObject.transform.GetChild(selectedParkPointIndex).gameObject;
        customerManager.musterilerList[selectedParkPointIndex] = this.gameObject;               //YENÝ KOD
        customerManager.siparisSirasi.Add(this.gameObject);
        //customerManager.musterilerQueue.Enqueue(this.gameObject);                               //YENÝ KOD
        //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YENÝ KOD


        musteriOlunanKonum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        buNpcMusteriMi = true;
        npcScript.buNpcMusteriMi = true;

        alinanYemekAdedi = 0;

        GoForBuy();

        //this.gameObject.transform.position = new Vector3(selectedParkPoint.transform.position.x, selectedParkPoint.transform.position.y, selectedParkPoint.transform.position.z);
    }   //NPC müþteri olduðunda çalýþýr.



    private int SelectHowManyFoodYouWant()
    {
        int range = UnityEngine.Random.Range(1, 101);

        if (range <= 45)
        {
            return 1;
        }
        else if (range <= 80)
        {
            return 2;
        }
        else if (range <= 100)
        {
            return 3;
        }
        else
        {
            return 0;
        }
        //Debug.Log("istenen yemek adedi: " + istenenYemekAdedi);

    }   //Kaç adet yemek istediðini seçer (1,2,3) (sýrayla: %45, %35, %20)
    private string SelectWhichFoodYouWant()
    {
        FoodManager foodManager;
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").gameObject.GetComponent<FoodManager>();
        return foodManager.ChooseRandomBuyableFood();
    }   //Hangi yemeði istediðini seçer
    public void SuEkseneDogruBak()
    {

        if ((durumAciklamasi == "Stand Önündeyim" || durumAciklamasi == "Sipariþ Verdim") && buNpcMusteriMi == true)
        {
            Quaternion targetRotation;


            switch (customerManager.bakilacakYon)
            {
                case CustomerManager.BakilacakYon.artiX:
                    targetRotation = Quaternion.LookRotation((new Vector3(this.transform.position.x + 10, this.transform.position.y, this.transform.position.z)) - transform.position);
                    break;
                case CustomerManager.BakilacakYon.eksiX:
                    targetRotation = Quaternion.LookRotation((new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z)) - transform.position);
                    break;
                case CustomerManager.BakilacakYon.artiZ:
                    targetRotation = Quaternion.LookRotation((new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 10)) - transform.position);
                    break;
                case CustomerManager.BakilacakYon.eksiZ:
                    targetRotation = Quaternion.LookRotation((new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 10)) - transform.position);
                    break;
                default:
                    targetRotation = Quaternion.LookRotation((new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)) - transform.position);
                    break;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);


        }

    }



    void GoForBuy()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;

        navMeshAgent.destination = selectedParkPoint.gameObject.transform.position;
        durumAciklamasi = "Stand Önüne Doðru Gidiyorum";
    }   //satýn alma yapmak için stand önüne yürütür
    void RunWhenYouArrive()
    {
        if (buNpcMusteriMi == true && hedefeVardim == false && navMeshAgent.remainingDistance <= 0 && durumAciklamasi == "Stand Önüne Doðru Gidiyorum")
        {
            hedefeVardim = true;
            durumAciklamasi = "Stand Önündeyim";

            istenenYemekAdedi = SelectHowManyFoodYouWant();
            istenenYemek = SelectWhichFoodYouWant();

            Debug.Log("Ben " + istenenYemekAdedi + " tane " + istenenYemek + " alýyým.");

            durumAciklamasi = "Sipariþ Verdim";
        }
    }   //GoForBuy(); dan sonra hedef noktaya eriþtiðinde çalýþýr
    void GoBack()
    {
        if (durumAciklamasi == "Sipariþ Verdim" && siparisTamamlandiMi == true)
        {
            customerManager.musterilerList[selectedParkPointIndex] = null;      //YENÝ KOD
            customerManager.siparisSirasi.Remove(this.gameObject);
            //customerManager.musterilerQueue.Dequeue();  //YENÝ KOD
            //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YENÝ KOD


            durumAciklamasi = "Sipariþimi Aldým, Ayrýlýyorum";
            hedefeVardim = false;
            customerManager.parkPointsBusy[selectedParkPointIndex] = false;
            selectedParkPoint = null;
            buNpcMusteriMi = false;
            npcScript.buNpcMusteriMi = false;


            switch (npcScript.directionToGo)
            {
                case "+x":
                    navMeshAgent.destination = new Vector3(musteriOlunanKonum.x + 60, musteriOlunanKonum.y, musteriOlunanKonum.z);
                    break;
                case "-x":
                    navMeshAgent.destination = new Vector3(musteriOlunanKonum.x - 60, musteriOlunanKonum.y, musteriOlunanKonum.z);
                    break;
                case "+z":
                    navMeshAgent.destination = new Vector3(musteriOlunanKonum.x, musteriOlunanKonum.y, musteriOlunanKonum.z + 60);
                    break;
                case "-z":
                    navMeshAgent.destination = new Vector3(musteriOlunanKonum.x, musteriOlunanKonum.y, musteriOlunanKonum.z - 60);
                    break;
                default:
                    break;
            }
        }

    }   //satýn alma bittikten sonra geri döner


    void YemegiAl()
    {
        alinanYemekAdedi = alinanYemekAdedi + 1;
        if(alinanYemekAdedi >= istenenYemekAdedi)
        {
            siparisTamamlandiMi = true;
            GoBack();
        }
    }   //Garsonun verdiði yemeði alýr





}
