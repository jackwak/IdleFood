using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [Header("State Variables")]
    public State RunToCustomerState;
    public State RunToMachineState;
    public bool HasAnyCustomer;
    public bool HasAnyOrder;

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
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);
            //yeni customerdan ��kart

            return RunToCustomerState;
        }
        else if (HasAnyOrder)
        {
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);
            //m�sait sipari�i al (makinesi dolu olmayan sipari�i)
            //sipari�i waiterda tut
            //geneldeki sipari�ten ��kart

            return RunToMachineState;
        }
        else
        {
            if (!_isSleeping)
            {
                //_waiter.Animator.SetBool("isSleeping", true);
                _waiter.SleepingGO.SetActive(true);

                _isSleeping = true;
            }

            return this;
        }
    }

    public void ResetVariables()
    {
        _isSleeping = false;

        _waiter.Animator.SetBool("isSleeping", false);
        _waiter.SleepingGO.SetActive(false);
    }
}
