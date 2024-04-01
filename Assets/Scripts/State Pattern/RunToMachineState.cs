using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToMachineState : State
{
    [Header("States")]
    public State PrepareState;

    [Header("Transitions")]
    public bool IsArrivedToMachine;

    [Header("References")]
    private CommandInvoker _commandInvoker;
    private Waiter _waiter;

    [Header("Variables")]
    private bool _isRunning;
    private Transform _machinePosition;

    private void Awake()
    {
        _commandInvoker = new CommandInvoker();
        _waiter = transform.parent.parent.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsArrivedToMachine)
        {
            _waiter.Animator.SetBool("IsRunning", false);
            _isRunning = false;
            IsArrivedToMachine = false;

            return PrepareState;
        }
        else
        {
            if (_waiter.CurrentOrder.Machine != null) // bu if gereksiz olabilir
            {
                if (!_isRunning)
                {
                    _waiter.Animator.SetBool("IsRunning", true);
                    _machinePosition = _waiter.CurrentOrder.Machine.FoodPrepareTransfrom;
                    RunWaiterCommand(_machinePosition.position);
                    _isRunning = true;
                }

                // is arrived to machine?
                if ((_waiter.transform.position - _waiter.CurrentOrder.Machine.FoodPrepareTransfrom.position).magnitude < 1)
                {
                    IsArrivedToMachine = true;
                    _waiter.transform.DORotateQuaternion(_machinePosition.rotation, _waiter.RotationSpeed);
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
}
