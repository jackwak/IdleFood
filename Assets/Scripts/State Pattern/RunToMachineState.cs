using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToMachineState : State
{
    [Header("State Variables")]
    public State PrepareState;
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

            return PrepareState;
        }
        else
        {
            if (!_isRunning)
            {
                // her �eyden �nce m�sait makine olmas� gerekiyor
                // m�sait makinenin pozisyonunu getir / get the avaible machine position
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
