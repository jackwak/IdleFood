using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [HideInInspector] public Transform[] CustomersTransform;
    public List<Customer> Customers = new();

    private void Start()
    {
        // Initialize Customer Transforms
        Transform customerTranforms = transform.Find("Customer Transforms");

        for (int i = 0; i < customerTranforms.childCount; i++)
        {
            CustomersTransform[i] = customerTranforms.GetChild(i);
        }
    }

    public bool AddToLine(Customer customer)
    {
        if (CustomersTransform.Length > Customers.Count)
        {
            Customers.Add(customer);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFromLine(Customer customer)
    {
        return Customers.Remove(customer);
    }

    public Customer GetAvaibleCustomer()
    {
        for (int i = 0; i < Customers.Count; i++)
        {
            Customer customer = Customers[i];

            if (!customer.HasOrder)
            {
                return customer;
            } 
        }

        return null;
    }
}
