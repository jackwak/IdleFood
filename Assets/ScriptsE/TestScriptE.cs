using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestScriptE : MonoBehaviour
{
    //NavMeshAgent agent;

    CustomerManager customerManager;
    // Start is called before the first frame update
    void Start()
    {
        customerManager = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
        //agent = this.gameObject.transform.GetComponent<NavMeshAgent>();
        //agent.destination = new Vector3(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        //float range = UnityEngine.Random.Range(-0.5f,0.50000001f);
        //Debug.Log(range);
        //transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    public void SiradakiMusterininIsteginiBirArttýr()
    {
        customerManager.siparisVermeSirasi[0].GetComponent<Customer>().MusteriyeYemekVer();
    }
}
