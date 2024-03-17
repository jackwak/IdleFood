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
    [SerializeField] int istenenYemekAdedi; //M��terinin istedi�i yemek adedi. (1,2,3)
    [SerializeField] int alinanYemekAdedi;  //Sipari� verdi�i yemeklerden ka� tanesini ald�?
    [SerializeField] string istenenYemek;

    [SerializeField] bool hedefeVardim;
    [SerializeField] string durumAciklamasi;
    //Ben D�z NPC'yim
    //Ben M��teri Olamad�m
    //Stand �n�ne Do�ru Gidiyorum
    //Stand �n�ndeyim
    //Sipari� Verdim
    //Sipari�imi Ald�m, Ayr�l�yorum

    [SerializeField] bool siparisTamamlandiMi;
    Vector3 musteriOlunanKonum;

    [SerializeField] bool alinanYemegiBirArtt�rSadeceDevMod;    //TEST AMA�LI KULLANILIR. TAM S�R�MDE S�L�NEB�L�R.

    private void Awake()
    {
        npcScript = this.gameObject.GetComponent<Npc>();
        musteriOlmaSansi = 0;
        buNpcMusteriMi = false;
        selectedParkPointIndex = -1;
        durumAciklamasi = "Ben D�z NPC'yim";
    }

    void Update()
    {
        RunWhenYouArrive(); //stand �n�ne var�nca �al���r

        SuEkseneDogruBak(); //stand �n�ne vard�ktan sonra �al���r

        if(alinanYemegiBirArtt�rSadeceDevMod == true)
        {
            alinanYemegiBirArtt�rSadeceDevMod = false;
            YemegiAl();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BecomeCustomerArea" && buNpcMusteriMi == false && durumAciklamasi == "Ben D�z NPC'yim")
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
                    durumAciklamasi = "Ben M��teri Olamad�m";
                }
                break;
            }
        }
    }   //NPC'nin m��teri olup olmad���n�, �ansa ba�l� ayarlar.
    private void RunWhenYouBecomeCustomer()
    {
        this.gameObject.name = "Musteri " + selectedParkPointIndex;                             //YEN� KOD
        customerManager.parkPointsBusy[selectedParkPointIndex] = true;
        selectedParkPoint = customerManager.gameObject.transform.GetChild(selectedParkPointIndex).gameObject;
        customerManager.musterilerList[selectedParkPointIndex] = this.gameObject;               //YEN� KOD
        customerManager.siparisSirasi.Add(this.gameObject);
        //customerManager.musterilerQueue.Enqueue(this.gameObject);                               //YEN� KOD
        //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YEN� KOD


        musteriOlunanKonum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        buNpcMusteriMi = true;
        npcScript.buNpcMusteriMi = true;

        alinanYemekAdedi = 0;

        GoForBuy();

        //this.gameObject.transform.position = new Vector3(selectedParkPoint.transform.position.x, selectedParkPoint.transform.position.y, selectedParkPoint.transform.position.z);
    }   //NPC m��teri oldu�unda �al���r.



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

    }   //Ka� adet yemek istedi�ini se�er (1,2,3) (s�rayla: %45, %35, %20)
    private string SelectWhichFoodYouWant()
    {
        FoodManager foodManager;
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").gameObject.GetComponent<FoodManager>();
        return foodManager.ChooseRandomBuyableFood();
    }   //Hangi yeme�i istedi�ini se�er
    public void SuEkseneDogruBak()
    {

        if ((durumAciklamasi == "Stand �n�ndeyim" || durumAciklamasi == "Sipari� Verdim") && buNpcMusteriMi == true)
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
        durumAciklamasi = "Stand �n�ne Do�ru Gidiyorum";
    }   //sat�n alma yapmak i�in stand �n�ne y�r�t�r
    void RunWhenYouArrive()
    {
        if (buNpcMusteriMi == true && hedefeVardim == false && navMeshAgent.remainingDistance <= 0 && durumAciklamasi == "Stand �n�ne Do�ru Gidiyorum")
        {
            hedefeVardim = true;
            durumAciklamasi = "Stand �n�ndeyim";

            istenenYemekAdedi = SelectHowManyFoodYouWant();
            istenenYemek = SelectWhichFoodYouWant();

            Debug.Log("Ben " + istenenYemekAdedi + " tane " + istenenYemek + " al�y�m.");

            durumAciklamasi = "Sipari� Verdim";
        }
    }   //GoForBuy(); dan sonra hedef noktaya eri�ti�inde �al���r
    void GoBack()
    {
        if (durumAciklamasi == "Sipari� Verdim" && siparisTamamlandiMi == true)
        {
            customerManager.musterilerList[selectedParkPointIndex] = null;      //YEN� KOD
            customerManager.siparisSirasi.Remove(this.gameObject);
            //customerManager.musterilerQueue.Dequeue();  //YEN� KOD
            //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YEN� KOD


            durumAciklamasi = "Sipari�imi Ald�m, Ayr�l�yorum";
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

    }   //sat�n alma bittikten sonra geri d�ner


    void YemegiAl()
    {
        alinanYemekAdedi = alinanYemekAdedi + 1;
        if(alinanYemekAdedi >= istenenYemekAdedi)
        {
            siparisTamamlandiMi = true;
            GoBack();
        }
    }   //Garsonun verdi�i yeme�i al�r





}
