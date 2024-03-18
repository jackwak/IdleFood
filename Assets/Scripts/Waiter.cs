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

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }




}
