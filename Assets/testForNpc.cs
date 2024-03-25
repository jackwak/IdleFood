using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testForNpc : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 x = new Vector3(this.transform.position.x + 30, this.transform.position.y, this.transform.position.z);
        this.GetComponent<NavMeshAgent>().SetDestination(x);
    }

}
