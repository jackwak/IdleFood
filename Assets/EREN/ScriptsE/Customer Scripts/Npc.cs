using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    SpawnerManager spawnerManager;
    Rigidbody rb;

    bool isNew; //npc yeni mi spawnlandý
    public string directionToGo; //npc nin gideceði yönü tutar +x -x +z -z
    public float hareketHiziX;
    public bool buNpcMusteriMi;
    bool varyantKonumlarAcilsinMi;

    Animator animator;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        spawnerManager = GameObject.FindGameObjectWithTag("SpawnerManager").gameObject.GetComponent<SpawnerManager>();
        hareketHiziX = spawnerManager.hareketHizi;
        isNew = true;
        buNpcMusteriMi = false;
        varyantKonumlarAcilsinMi = spawnerManager.varyantKonumlarAcilsinMi;
    }
    private void Update()
    {
        NpcIlerlemeFonksiyonu();
    }

    private void OnTriggerEnter(Collider other)
    {
        NpcGidecegiYonuBelirleme(other);


        NpcOldurur(other);
    }
    private void OnCollisionStay(Collision collision)
    {
        //NpcBaskaNpcyeCarparsaYonDegistir(collision);
    }


    void NpcIlerlemeFonksiyonu()
    {
        if (isNew == false && buNpcMusteriMi == false)
        {
            if (spawnerManager.npclerinYurumeMetodu == SpawnerManager.WalkingMethod.Transform)
            {
                transform.Translate(Vector3.forward * hareketHiziX * Time.deltaTime);
            }
            else if (spawnerManager.npclerinYurumeMetodu == SpawnerManager.WalkingMethod.NavMeshAgent)
            {
                NavMeshAgent myNavMeshAgent;
                myNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
                myNavMeshAgent.enabled = true;
                myNavMeshAgent.speed = hareketHiziX;
                switch (directionToGo)
                {
                    case "+x":
                        myNavMeshAgent.destination = new Vector3(this.gameObject.transform.position.x + 99, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                        break;
                    case "-x":
                        myNavMeshAgent.destination = new Vector3(this.gameObject.transform.position.x - 99, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                        break;
                    case "+z":
                        myNavMeshAgent.destination = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 99);
                        break;
                    case "-z":
                        myNavMeshAgent.destination = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 99);
                        break;
                }



            }
            else if (spawnerManager.npclerinYurumeMetodu.ToString() == "AddForce")
            {
                rb.AddForce(Vector3.forward * hareketHiziX * Time.deltaTime * 10);
            }

        }
    }
    void NpcGidecegiYonuBelirleme(Collider other)
    {
        if (isNew == true && buNpcMusteriMi == false)
        {
            if (other.gameObject.tag == "SpawnerPoint +x")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                isNew = false;
                spawnerManager.npcList.Add(this.gameObject);
                directionToGo = "+x";
            }
            else if (other.gameObject.tag == "SpawnerPoint -x")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
                isNew = false;
                spawnerManager.npcList.Add(this.gameObject);
                directionToGo = "-x";
            }
            else if (other.gameObject.tag == "SpawnerPoint +z")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                isNew = false;
                spawnerManager.npcList.Add(this.gameObject);
                directionToGo = "+z";
            }
            else if (other.gameObject.tag == "SpawnerPoint -z")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                isNew = false;
                spawnerManager.npcList.Add(this.gameObject);
                directionToGo = "-z";
            }
            VaryantKonumlar();
        }
    }
    void NpcOldurur(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            spawnerManager.npcList.Remove(this.gameObject);
            if (spawnerManager.currentNpcObjectCount > 0)
            {
                spawnerManager.currentNpcObjectCount--;
            }
            Destroy(this.gameObject);
        }
    }
    void NpcBaskaNpcyeCarparsaYonDegistir(Collision collision)
    {
        if (collision.gameObject.tag == "Npc" && directionToGo == "+x")
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
        }
        else if (collision.gameObject.tag == "Npc" && directionToGo == "-x")
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.01f);
        }
        else if (collision.gameObject.tag == "Npc" && directionToGo == "+z")
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.01f, this.transform.position.y, this.transform.position.z);
        }
        else if (collision.gameObject.tag == "Npc" && directionToGo == "-z")
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.01f, this.transform.position.y, this.transform.position.z);
        }
    }
    void VaryantKonumlar()
    {
        if (varyantKonumlarAcilsinMi == true)
        {
            float range = UnityEngine.Random.Range(-0.5f, 0.50000001f);

            if (directionToGo == "+x" || directionToGo == "-x")
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + range);
            }
            else if (directionToGo == "+z" || directionToGo == "-z")
            {
                this.transform.position = new Vector3(this.transform.position.x + range, this.transform.position.y, this.transform.position.z);
            }
        }


    }

}
