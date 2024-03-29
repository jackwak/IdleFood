using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [Header("References")]
    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public ProgressBarController ProgressBarController;
    public GameObject SleepingGO;


    [HideInInspector] public bool HasFoodOnHand;
    [HideInInspector] public bool HasAnyCustomer;
    [HideInInspector] public bool HasAnyOrder;

    [HideInInspector] public Customer CurrentCustomer;
    public Order CurrentOrder;


    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        ProgressBarController = GetComponent<ProgressBarController>();
    }

    public void SetWaiterAgentPosition(Vector3 position)
    {
        Agent.SetDestination(position);
    }
}
