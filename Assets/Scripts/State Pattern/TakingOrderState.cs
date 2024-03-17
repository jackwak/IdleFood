using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOrderState : State
{
    public State RunToMachineState;
    public bool IsOrderTook;

    public override State RunCurrentState()
    {
        if (IsOrderTook)
        {
            return RunToMachineState;
        }
        else
        {
            return this;
        }
    }
}
