using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBg : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(A());
    }

    IEnumerator A()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }
}
