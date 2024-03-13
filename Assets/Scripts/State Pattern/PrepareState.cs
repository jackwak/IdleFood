using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareState : State
{
    public State RunToCustomerState;

    public bool IsFoodCompleted;

    public override State RunCurrentState()
    {
        if (IsFoodCompleted)
        {
            return RunToCustomerState;
        }
        else
        {
            return this;
        }
    }
}
