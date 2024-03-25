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

    private void Awake()
    {
        _commandInvoker = new CommandInvoker();
        _waiter = transform.root.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsArrivedToMachine)
        {
            _isRunning = false;
            IsArrivedToMachine = false;

            return PrepareState;
        }
        else
        {
            if (!_isRunning)
            {
                Transform machinePosition = _waiter.CurrentOrder.Machine.FoodPrepareTransfrom;
                RunWaiterCommand(machinePosition.position);
                _isRunning = true;
            }

            // is arrived to machine?
            if ((_waiter.transform.position - _waiter.CurrentOrder.Machine.FoodPrepareTransfrom.position).magnitude < 0.1)
            {
                IsArrivedToMachine = true;
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
