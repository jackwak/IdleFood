using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private Transform _selectedWaiterTransform;

    private void Awake()
    {
        _commandInvoker = new CommandInvoker();
        _waiter = transform.parent.parent.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsArrivedToCustomer && HasFoodOnHand)
        {
            _isRunning = false;
            IsArrivedToCustomer = false;

            return GivingFoodState;
        }
        else if (IsArrivedToCustomer && !HasFoodOnHand)
        {
            _isRunning = false;
            IsArrivedToCustomer = false;

            return TakingOrderState;
        }
        else
        {
            if (!_isRunning)
            {
                HasFoodOnHand = _waiter.HasFoodOnHand;
                _waiter.Animator.SetBool("IsRunning", true);

                if (HasFoodOnHand)
                {
                    // siparis isteyen customera git
                    Vector3 position = _waiter.CurrentOrder.Customer.selectedWaiterPoint.transform.position;
                    _selectedWaiterTransform = _waiter.CurrentOrder.Customer.selectedWaiterPoint.transform;
                    RunWaiterCommand(position);
                }
                else
                {
                    //siparis vericek olan customera git
                    Vector3 position = _waiter.CurrentCustomer.selectedWaiterPoint.transform.position;
                    _selectedWaiterTransform = _waiter.CurrentCustomer.selectedWaiterPoint.transform;
                    RunWaiterCommand(position);
                }


                _isRunning = true;
            }

            if (IsWaiterReached())
            {
                IsArrivedToCustomer = true;
                _waiter.Animator.SetBool("IsRunning", false);
                _waiter.transform.DORotateQuaternion(_selectedWaiterTransform.rotation, _waiter.RotationSpeed);
            }

            return this;
        }
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

    public void RunWaiterCommand(Vector3 position)
    {
        ICommand command = new MoveCommand(_waiter, position);
        _commandInvoker.ExecuteCommand(command);
    }
}
