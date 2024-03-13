using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToMachineState : State
{
    public State PrepareState;

    public bool IsArrivedToMachine;

    public override State RunCurrentState()
    {
        if (IsArrivedToMachine)
        {
            return PrepareState;
        }
        else
        {
            return this;
        }
    }
}
