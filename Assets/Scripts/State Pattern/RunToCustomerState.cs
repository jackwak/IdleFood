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
        if (IsArrivedToCustomer && HasFoodOnHand)
        {
            return GivingFoodState;
        }
        else if (IsArrivedToCustomer && !HasFoodOnHand)
        {
            return TakingOrderState;
        }
        else
        {
            if (!_isRunning)
            {
                // hepsinden önce bu state e geçmesi için sipariþ bekleyen bir müþteri olmalý
                // sipariþ vericek olan müþterinin pozisyonunu getir / get the customer position who will order
                //RunWaiterCommand();
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
