using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public Customer Customer;
    public string Food;
    public Machine Machine;

    public Order(Customer customer, string food, Machine machine)
    {
        Customer = customer;
        Food = food;
        Machine = machine;
    }
}
