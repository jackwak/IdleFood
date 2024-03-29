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
    [SerializeField] public bool buNpcMusteriMi;
    [SerializeField] public GameObject selectedParkPoint;
    [SerializeField] public GameObject selectedWaiterPoint;
    [SerializeField] public int selectedParkPointIndex;
    [SerializeField] public int FoodCount; //M��terinin istedi�i yemek adedi. (1,2,3)
    [SerializeField] public int alinanYemekAdedi;  //Sipari� verdi�i yemeklerden ka� tanesini ald�?
    [SerializeField] public string OrderedFood;




    [SerializeField] public bool hedefeVardim;
    [SerializeField] public string durumAciklamasi;
    //Ben D�z NPC'yim
    //Ben M��teri Olamad�m
    //Stand �n�ne Do�ru Gidiyorum
    //Stand �n�ndeyim
    //Garson Bana Geliyor
    //Sipari�imi Al�yor
    //Sipari�imi Ald�
    //�r�n� Haz�rlamaya Gidiyor
    //Sipari� Verdim
    //Sipari�imi Getiriyor
    //Sipari�imi Ald�m, Ayr�l�yorum

    [SerializeField] public bool siparisTamamlandiMi;
    public Vector3 musteriOlunanKonum;

    //[SerializeField] public bool alinanYemegiBirArtt�rSadeceDevMod;    //TEST AMA�LI KULLANILIR. TAM S�R�MDE S�L�NEB�L�R.

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

        //if (alinanYemegiBirArtt�rSadeceDevMod == true)
        //{
        //    alinanYemegiBirArtt�rSadeceDevMod = false;
        //    YemegiAl();
        //}
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
        selectedWaiterPoint = selectedParkPoint.transform.GetChild(0).gameObject;
        customerManager.musterilerList[selectedParkPointIndex] = this.gameObject;               //YEN� KOD
        //customerManager.siparisVermeSirasi.Add(this.gameObject);
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
        int birYemekSansi = 0;
        int ikiYemekSansi = 0;
        int ucYemekSansi = 0;
        birYemekSansi = customerManager.birYemekSansi;
        ikiYemekSansi = customerManager.ikiYemekSansi;
        ucYemekSansi = customerManager.ucYemekSansi;

        int toplamYemekSansi = birYemekSansi + ikiYemekSansi + ucYemekSansi;


        int range = UnityEngine.Random.Range(1, toplamYemekSansi + 1);

        if (range <= birYemekSansi)
        {
            return 1;
        }
        else if (range <= birYemekSansi + ikiYemekSansi)
        {
            return 2;
        }
        else if (range <= toplamYemekSansi)
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

        if ((durumAciklamasi == "Stand �n�ndeyim" || durumAciklamasi == "Sipari� Verdim" || durumAciklamasi == "Garson Bana Geliyor") && buNpcMusteriMi == true)
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
            FoodCount = SelectHowManyFoodYouWant();
            OrderedFood = SelectWhichFoodYouWant();
            customerManager.siparisVermeSirasi.Add(this.gameObject);


            //Debug.Log("Ben " + FoodCount + " tane " + OrderedFood + " al�y�m.");

            if(runWhenYouArriveDelegate != null)
            {
                runWhenYouArriveDelegate();
            }

        }
    }   //GoForBuy(); dan sonra hedef noktaya eri�ti�inde �al���r
    private void GoBack()
    {
        if (siparisTamamlandiMi == true)
        {
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
            customerManager.musterilerList[selectedParkPointIndex] = null;      //YEN� KOD

            if (customerManager.specialForDevMode)
            {
                customerManager.siparisVermeSirasi.Remove(this.gameObject);
            }
            //customerManager.siparisVermeSirasi.Remove(this.gameObject);
            //customerManager.musterilerQueue.Dequeue();  //YEN� KOD
            //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YEN� KOD


            durumAciklamasi = "Sipari�imi Ald�m, Ayr�l�yorum";
            hedefeVardim = false;
            customerManager.parkPointsBusy[selectedParkPointIndex] = false;
            selectedParkPoint = null;
            selectedWaiterPoint = null;
            buNpcMusteriMi = false;
            npcScript.buNpcMusteriMi = false;


        }

    }   //sat�n alma bittikten sonra geri d�ner                  //ARTIK KULLANILMIYOR
    private void YemegiAl()
    {
        alinanYemekAdedi = alinanYemekAdedi + 1;
        if (alinanYemekAdedi >= FoodCount)
        {
            siparisTamamlandiMi = true;
            //GoBack();
        }
    }   //Garsonun verdi�i yeme�i al�r                      //ARTIK KULLANILMIYOR

    public void MusteriyeYemekVer()
    {
        this.alinanYemekAdedi += 1;
        if (this.alinanYemekAdedi >= this.FoodCount)
        {
            Vector3 leaveTarget = new Vector3();
            switch (this.npcScript.directionToGo)
            {
                case "+x":
                    leaveTarget = new Vector3(musteriOlunanKonum.x + 60, musteriOlunanKonum.y, musteriOlunanKonum.z);
                    break;
                case "-x":
                    leaveTarget = new Vector3(musteriOlunanKonum.x - 60, musteriOlunanKonum.y, musteriOlunanKonum.z);
                    break;
                case "+z":
                    leaveTarget = new Vector3(musteriOlunanKonum.x, musteriOlunanKonum.y, musteriOlunanKonum.z + 60);
                    break;
                case "-z":
                    leaveTarget = new Vector3(musteriOlunanKonum.x, musteriOlunanKonum.y, musteriOlunanKonum.z - 60);
                    break;
                default:
                    break;
            }
            this.navMeshAgent.SetDestination(leaveTarget);

            if (customerManager.specialForDevMode)
            {
                customerManager.siparisVermeSirasi.RemoveAt(0);
            }
            this.customerManager.musterilerList[selectedParkPointIndex] = null;
            this.customerManager.parkPointsBusy[selectedParkPointIndex] = false;
            this.durumAciklamasi = "Sipari�imi Ald�m, Ayr�l�yorum";
            
            //this.npcScript.buNpcMusteriMi = false; �al���nca t�m kod �al��m�yor
            this.hedefeVardim = false;
            this.selectedParkPoint = null;
            this.selectedWaiterPoint = null;
            this.buNpcMusteriMi = false;


        }
    }

    public delegate void RunWhenYouArriveDelegate();
    public static RunWhenYouArriveDelegate runWhenYouArriveDelegate;



}
