using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunToIdleState : State
{
    [Header("State Variables")]
    public State IdleState;
    public State RunToCustomerState;
    public State RunToMachineState;

    [Header("Transitions")]
    public bool IsArrivedIdlePosition;
    public bool HasAnyCustomer;
    public bool HasAnyOrder;

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
        if (HasAnyCustomer)
        {
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);
            //yeni müþteriyi listten çýkart

            return RunToCustomerState;
        }
        else if (OrderManager.Instance.HasAnyOrder)
        {
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);
            _waiter.CurrentOrder = OrderManager.Instance.GetOrder();

            return RunToMachineState;
        }
        else if (IsArrivedIdlePosition)
        {
            ResetVariables();

            return IdleState;
        }
        else
        {
            if (!_isRunning)
            {
                Transform avaibleTransform = IdlePositionManager.Instance.GetAvaibleIdlePosition(GetComponent<Waiter>());
                RunWaiterCommand(avaibleTransform.position);
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

    private void ResetVariables()
    {
        HasAnyCustomer = false;
        HasAnyOrder = false;

        _isRunning = false;
        _waiter.Agent.ResetPath();
    }
}
