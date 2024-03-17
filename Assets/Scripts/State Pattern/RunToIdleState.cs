using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunToIdleState : State
{
    [Header("State Variables")]
    public State IdleState;
    public State RunToCustomerState;
    public bool IsArrivedIdlePosition;
    public bool HasAnyCustomer;

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
        if (IsArrivedIdlePosition)
        {
            ResetVariables();

            return IdleState;
        }
        else if (HasAnyCustomer)
        {
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);

            return RunToCustomerState;
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
        _isRunning = false;
        _waiter.Agent.ResetPath();
    }
}
