using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToCustomerState : State
{
    public State GivingFoodState;
    public State TakingOrderState;

    public bool HasFoodOnHand;
    public bool IsArrivedToCustomer;

    public override State RunCurrentState()
    {
        if (IsArrivedToCustomer && HasFoodOnHand)
        {
            return GivingFoodState;
        }
        else if (IsArrivedToCustomer && !HasFoodOnHand)
        {
            return TakingOrderState;
        }
        else
        {
            return this;
        }
    }
}
