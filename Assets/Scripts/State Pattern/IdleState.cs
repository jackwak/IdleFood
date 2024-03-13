using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State RunToCustomerState;

    public bool HasAnyCustomer;

    public override State RunCurrentState()
    {
        if (HasAnyCustomer)
        {
            return RunToCustomerState;
        }
        else
        {
            return this;
        }
    }
}
