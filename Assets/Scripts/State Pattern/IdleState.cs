using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [Header("State Variables")]
    public State RunToCustomerState;
    public bool HasAnyCustomer;

    [Header("References")]
    private Waiter _waiter;

    [Header("Variables")]
    private bool _isSleeping;

    private void Awake()
    {
        _waiter = transform.root.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (HasAnyCustomer)
        {
            _waiter.Animator.SetBool("isSleeping", false);

            return RunToCustomerState;
        }
        else
        {
            if (!_isSleeping)
            {
                _waiter.Animator.SetBool("isSleeping", true);
            }

            return this;
        }
    }
}
