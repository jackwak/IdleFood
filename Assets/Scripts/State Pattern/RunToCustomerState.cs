using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToCustomerState : State
{
    [Header("State Variables")]
    public State GivingFoodState;
    public State TakingOrderState;

    public bool HasFoodOnHand;
    public bool IsArrivedToCustomer;

    [Header("References")]
    private CommandInvoker _commandInvoker;
    private Waiter _waiter;

    [Header("Variables")]
    private bool _isRunning;

    private void Awake()
    {
        _commandInvoker = new CommandInvoker();
        _waiter = transform.root.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsArrivedToCustomer && _waiter.HasFoodOnHand)
        {
            _isRunning = false;

            return GivingFoodState;
        }
        else if (IsArrivedToCustomer && !_waiter.HasFoodOnHand)
        {
            _isRunning = false;

            return TakingOrderState;
        }
        else
        {
            if (!_isRunning)
            {
                if (_waiter.CurrentOrder != null)
                {
                    HasFoodOnHand = true;

                    // sipariþ isteyen customera git
                    // yemeði poola yolla
                    //müþterinin yeemeeðini ver
                }
                else
                {
                    //sipariþ vericek olan customera git
                }

                _isRunning = true;
            }

            return this;
        }
    }

    public void RunWaiterCommand(Vector3 position)
    {
        ICommand command = new MoveCommand(_waiter, position);
        _commandInvoker.ExecuteCommand(command);
    }
}
