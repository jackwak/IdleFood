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
    public bool CanTakeOrder;

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
            _waiter.HasAnyCustomer = false;
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);
            //customerý çek ve waiterýn current customerý yap
            _waiter.CurrentCustomer = CustomerManager.Instance.siparisVermeSirasi[0].GetComponent<Customer>();
            //yeni müþteriyi listten çýkart
            CustomerManager.Instance.siparisVermeSirasi.RemoveAt(0);
            

            return RunToCustomerState;
        }
        else if (CanTakeOrder)
        {
            _waiter.HasAnyCustomer = false;
            ResetVariables();
            IdlePositionManager.Instance.RemoveWaiterFromIdlePosition(_waiter);

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

            HasAnyCustomer = _waiter.HasAnyCustomer;
            Debug.Log(HasAnyCustomer);

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
        CanTakeOrder = false;

        _isRunning = false;
        _waiter.Agent.ResetPath();
    }
}
