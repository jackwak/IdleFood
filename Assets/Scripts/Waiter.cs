using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent Agent;
    [HideInInspector]
    public Animator Animator;
    public GameObject SleepingGO;
    public bool HasFoodOnHand;

    public Customer CurrentCustomer;
    public Order CurrentOrder;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    public void SetWaiterAgentPosition(Vector3 position)
    {
        Agent.SetDestination(position);
    }
}
