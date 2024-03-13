using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToIdleState : State
{
    public State IdleState;

    public bool IsArrivedIdlePosition;

    public override State RunCurrentState()
    {
        if (IsArrivedIdlePosition)
        {
            return IdleState;
        }
        else
        {
            return this;
        }
    }
}
