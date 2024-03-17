using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingFoodState : State
{
    [Header("State Variables")]
    public State RunToIdleState;
    public State RunToCustomerState;
    public bool HasFoodOnHand;
    public bool HasAnyCustomer;
    

    [Header("References")]
    private Waiter _waiter;
    private CommandInvoker _commandInvoker;

    [Header("Variables")]
    private bool _isFoodGiving;

    private void Awake()
    {
        _waiter = transform.root.GetComponent<Waiter>();
        _commandInvoker = new CommandInvoker();
    }

    public override State RunCurrentState()
    {
        if (HasAnyCustomer)
        {
            _isFoodGiving = false;

            return RunToCustomerState;
        }
        else if (!HasFoodOnHand)
        {
            _isFoodGiving = false;

            return RunToIdleState;
        }
        else
        {
            if (!_isFoodGiving)
            {
                // command kullanmadan yapýlabilir.
                GiveFoodCommand();

                _isFoodGiving = true;
            }

            return this;
        }
    }

    private void GiveFoodCommand()
    {
        ICommand command = new GiveFoodCommand(_waiter);
        _commandInvoker.ExecuteCommand(command);
    }

}
