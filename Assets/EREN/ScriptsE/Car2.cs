using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : MonoBehaviour
{
    private float speed;
    private void Start()
    {
        speed = Random.Range(11f, 14f);
    }
    private void Update()
    {
        CarMove();
    }
    private void CarMove()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarEnemy")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CarEnemy")
        {
            Destroy(gameObject);
        }
    }

}
