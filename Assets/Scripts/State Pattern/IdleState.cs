using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [Header("States")]
    public State RunToCustomerState;
    public State RunToMachineState;

    [Header("Transitions")]
    public bool HasAnyCustomer;
    public bool HasAnyOrder;
    public bool CanTakeOrder;

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
            //yeni customerdan cikart ve waiterýn current customerýna ekle
            
            _waiter.CurrentCustomer = CustomerManager.Instance.siparisVermeSirasi[0].GetComponent<Customer>();
            

            CustomerManager.Instance.siparisVermeSirasi.RemoveAt(0);

            return RunToCustomerState;
        }
        else if (CanTakeOrder)
        {
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);

            return RunToMachineState;
        }
        else
        {
            if (!_isSleeping)
            {
                //sleep anim

                _waiter.SleepingGO.SetActive(true);

                Vector3 directionToTarget = _waiter.SleepingGO.transform.position - Camera.main.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                _waiter.SleepingGO.transform.rotation = targetRotation;

                _isSleeping = true;
            }

            HasAnyCustomer = _waiter.HasAnyCustomer;

            HasAnyOrder = OrderManager.Instance.HasAnyOrder;
            if (HasAnyOrder && !HasAnyCustomer)
            {
                _waiter.CurrentOrder = OrderManager.Instance.GetOrder();
                if (_waiter.CurrentOrder != null)
                {
                    CanTakeOrder = true;
                }
            }

            return this;
        }
    }

    public void ResetVariables()
    {
        CanTakeOrder = false;
        HasAnyCustomer = false;
        HasAnyOrder = false;
        _isSleeping = false;
        _waiter.HasAnyCustomer = false;

        //_waiter.Animator.SetBool("isSleeping", false);
        _waiter.SleepingGO.SetActive(false);
    }
}
