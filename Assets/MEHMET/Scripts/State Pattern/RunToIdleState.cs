using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
            //customerý çek ve waiterýn current customerý yap
            //yeni müþteriyi listten çýkart

            return RunToCustomerState;
        }
        else if (HasAnyOrder)
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
                Transform avaibleTransform = IdlePositionManager.Instance.GetAvaibleIdlePosition(_waiter);
                RunWaiterCommand(avaibleTransform.position);
                _isRunning = true;
            }

            if (IsWaiterReached())
            {
                IsArrivedIdlePosition = true;
            }

            HasAnyOrder = OrderManager.Instance.HasAnyOrder;

            return this;
        }
    }

    public void RunWaiterCommand(Vector3 position)
    {
        ICommand command = new MoveCommand(_waiter, position);
        _commandInvoker.ExecuteCommand(command);
    }

    public bool IsWaiterReached()
    {
        NavMeshAgent agent = _waiter.Agent;
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void ResetVariables()
    {
        HasAnyCustomer = false;
        HasAnyOrder = false;
        IsArrivedIdlePosition = false;

        _isRunning = false;
        _waiter.Agent.ResetPath();
    }
}
