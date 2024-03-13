using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingFoodState : State
{
    public State RunToIdleState;

    public bool HasFoodOnHand;

    public override State RunCurrentState()
    {
        if (!HasFoodOnHand)
        {
            return RunToIdleState;
        }
        else
        {
            return this;
        }
    }
}
