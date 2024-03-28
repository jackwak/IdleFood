using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    [Header("References")]
    public GameObject[] MachinePositionsManager;

    [Header("Variables")]
    public List<Customer> Customers;
    public List<string> Foods;

    [Header("Transitions")]
    public bool HasAnyOrder;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Foods.Count != 0)
        {
            HasAnyOrder = true;
        }
    }

    /*public bool AddOrder(Customer customer)
    {
        for (int i = 0; i < customer.FoodCount; i++)
        {
            Customers.Add(customer);
            Foods.Add(customer.OrderedFood);
            return true;
        }

        return false;
    }*/

    public Order GetOrder()
    {
        //if 0.indeksteki yemeðin makinesi boþsa 0. indeksteki orderý gettir
        for (int i = 0; i < Foods.Count; i++)
        {
            for (int j = 0; j < MachinePositionsManager.Length; j++)
            {
                // makinenin ismini al
                string machineName = MachinePositionsManager[j].name.Split(" ")[0];

                //yemeðin makinesini bul
                if (Foods[i] == machineName)
                {
                    MachinePositionManager machinePositionManager = MachinePositionsManager[j].GetComponent<MachinePositionManager>();
                    if (machinePositionManager.CheckAvaibleMachine())
                    {
                        Machine machine = machinePositionManager.GetAvaibleMachine();
                        Order order = new Order(Customers[i], Foods[i], machine);

                        Foods.RemoveAt(i);
                        Customers.RemoveAt(i);

                        return order;
                    }
                }
            }
        }
        return null;
    }

    public void SetMachineToAvailable(Machine machine, string machineName)
    {
        for (int i = 0; i < MachinePositionsManager.Length; i++)
        {
            string name = MachinePositionsManager[i].name.Split(" ")[0];
            if (machineName == name)
            {
                MachinePositionsManager[i].GetComponent<MachinePositionManager>().SetMachineToAvailable(machine);
            }
        }
    }



}
