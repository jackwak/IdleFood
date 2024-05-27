using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Customer : MonoBehaviour
{



    Npc npcScript;
    CustomerManager customerManager;
    NavMeshAgent navMeshAgent;

    [SerializeField] public float musteriOlmaSansi;
    [SerializeField] public bool buNpcMusteriMi;
    [SerializeField] public GameObject selectedParkPoint;
    [SerializeField] public GameObject selectedWaiterPoint;
    [SerializeField] public int selectedParkPointIndex;
    [SerializeField] public int FoodCount; //Müþterinin istediði yemek adedi. (1,2,3)
    [SerializeField] public int alinanYemekAdedi;  //Sipariþ verdiði yemeklerden kaç tanesini aldý?
    [SerializeField] public string OrderedFood;
    




    [SerializeField] public bool hedefeVardim;
    [SerializeField] public string durumAciklamasi;
    //Ben Düz NPC'yim
    //Ben Müþteri Olamadým
    //Stand Önüne Doðru Gidiyorum
    //Stand Önündeyim
    //Garson Bana Geliyor
    //Sipariþimi Alýyor
    //Sipariþimi Aldý
    //Ürünü Hazýrlamaya Gidiyor
    //Sipariþ Verdim
    //Sipariþimi Getiriyor
    //Sipariþimi Aldým, Ayrýlýyorum

    [SerializeField] public bool siparisTamamlandiMi;
    public Vector3 musteriOlunanKonum;

    Animator animator;

    //[SerializeField] public bool alinanYemegiBirArttýrSadeceDevMod;    //TEST AMAÇLI KULLANILIR. TAM SÜRÜMDE SÝLÝNEBÝLÝR.

    private void Awake()
    {
        //animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        npcScript = this.gameObject.GetComponent<Npc>();
        musteriOlmaSansi = 0;
        buNpcMusteriMi = false;
        selectedParkPointIndex = -1;
        durumAciklamasi = "Ben Düz NPC'yim";
    }

    void Update()
    {
        RunWhenYouArrive(); //stand önüne varýnca çalýþýr

        //SuEkseneDogruBak(); //stand önüne vardýktan sonra çalýþýr
        SuEkseneDogruBakYeni();

        //if (alinanYemegiBirArttýrSadeceDevMod == true)
        //{
        //    alinanYemegiBirArttýrSadeceDevMod = false;
        //    YemegiAl();
        //}
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



    int howManyPointIsUsingRightNow;
    private void ChooseCustomerOrNot()
    {
        howManyPointIsUsingRightNow = 0;
        for (int i = 0; i < customerManager.parkPointsBusy.Length; i++)
        {
            if (customerManager.parkPointsBusy[i] == true)
            {
                howManyPointIsUsingRightNow++;
            }
        }

        for (int i = 0; i < customerManager.parkPointsBusy.Length; i++)
        {
            if (customerManager.parkPointsBusy[i] == false && howManyPointIsUsingRightNow < customerManager.kacParkPointKullanilabilir)
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
        selectedWaiterPoint = selectedParkPoint.transform.GetChild(0).gameObject;
        customerManager.musterilerList[selectedParkPointIndex] = this.gameObject;               //YENÝ KOD
        //customerManager.siparisVermeSirasi.Add(this.gameObject);
        //customerManager.musterilerQueue.Enqueue(this.gameObject);                               //YENÝ KOD
        //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YENÝ KOD


        musteriOlunanKonum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        buNpcMusteriMi = true;
        npcScript.buNpcMusteriMi = true;

        alinanYemekAdedi = 0;
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();

        GoForBuy();

        //this.gameObject.transform.position = new Vector3(selectedParkPoint.transform.position.x, selectedParkPoint.transform.position.y, selectedParkPoint.transform.position.z);
    }   //NPC müþteri olduðunda çalýþýr.

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

    }   //Kaç adet yemek istediðini seçer (1,2,3) (sýrayla: %45, %35, %20)
    private string SelectWhichFoodYouWant()
    {
        FoodManager foodManager;
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").gameObject.GetComponent<FoodManager>();
        return foodManager.ChooseRandomBuyableFood();
    }   //Hangi yemeði istediðini seçer
    public void SuEkseneDogruBak()
    {

        if ((durumAciklamasi == "Stand Önündeyim" || durumAciklamasi == "Sipariþ Verdim" || durumAciklamasi == "Garson Bana Geliyor") && buNpcMusteriMi == true)
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
    public void SuEkseneDogruBakYeni()
    {
        if ((durumAciklamasi == "Stand Önündeyim" || durumAciklamasi == "Sipariþ Verdim" || durumAciklamasi == "Garson Bana Geliyor") && buNpcMusteriMi == true)
        {
            Quaternion targetRotation = selectedParkPoint.transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

        }

    }
    public void SuEkseneDogruBakYeniYeni()
    {


        string currentSceneName = SceneManager.GetActiveScene().name;
        switch (currentSceneName)
        {
            case "Level1":
                if ((durumAciklamasi == "Stand Önündeyim" || durumAciklamasi == "Sipariþ Verdim" || durumAciklamasi == "Garson Bana Geliyor") && buNpcMusteriMi == true)
                {
                    Quaternion targetRotation = selectedParkPoint.transform.rotation;

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
                }
                break;
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
            FoodCount = SelectHowManyFoodYouWant();
            OrderedFood = SelectWhichFoodYouWant();
            customerManager.siparisVermeSirasi.Add(this.gameObject);
            animator.SetBool("isWalking", false);

            //ShowBubble();
            //this.transform.Find("Bubble").gameObject.SetActive(true);
            //this.transform.GetChild(1).gameObject.SetActive(true);


            //Debug.Log("Ben " + FoodCount + " tane " + OrderedFood + " alýyým.");



        }
    }   //GoForBuy(); dan sonra hedef noktaya eriþtiðinde çalýþýr
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
            customerManager.musterilerList[selectedParkPointIndex] = null;      //YENÝ KOD

            if (customerManager.specialForDevMode)
            {
                customerManager.siparisVermeSirasi.Remove(this.gameObject);
            }
            //customerManager.siparisVermeSirasi.Remove(this.gameObject);
            //customerManager.musterilerQueue.Dequeue();  //YENÝ KOD
            //customerManager.siradakiSiparisinMusterisi = customerManager.musterilerQueue.Peek();    //YENÝ KOD


            durumAciklamasi = "Sipariþimi Aldým, Ayrýlýyorum";
            hedefeVardim = false;
            customerManager.parkPointsBusy[selectedParkPointIndex] = false;
            selectedParkPoint = null;
            selectedWaiterPoint = null;
            buNpcMusteriMi = false;
            npcScript.buNpcMusteriMi = false;


        }

    }   //satýn alma bittikten sonra geri döner                  //ARTIK KULLANILMIYOR
    private void YemegiAl()
    {
        alinanYemekAdedi = alinanYemekAdedi + 1;
        if (alinanYemekAdedi >= FoodCount)
        {
            siparisTamamlandiMi = true;
            //GoBack();
        }
    }   //Garsonun verdiði yemeði alýr                      //ARTIK KULLANILMIYOR
    public void ShowBubble()
    {
        this.transform.Find("Bubble").gameObject.SetActive(true);
    }


    public void MusteriyeYemekVer()
    {
        this.alinanYemekAdedi += 1;
        transform.Find("Bubble").GetComponent<FoodBubble>().SetCountText();
        if (this.alinanYemekAdedi >= this.FoodCount)
        {
            transform.Find("Bubble").gameObject.SetActive(false);
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
            this.durumAciklamasi = "Sipariþimi Aldým, Ayrýlýyorum";

            //this.npcScript.buNpcMusteriMi = false; Çalýþýnca tüm kod çalýþmýyor
            this.hedefeVardim = false;
            this.selectedParkPoint = null;
            this.selectedWaiterPoint = null;
            this.buNpcMusteriMi = false;

            animator.SetBool("isWalking", true);


        }
    }




}
