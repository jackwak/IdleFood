using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingFoodState : State
{
    [Header("State Variables")]
    public State RunToIdleState;
    public State RunToCustomerState;

    [Header("Transitions")]
    public bool HasFoodOnHand;

    [Header("References")]
    private Waiter _waiter;

    [Header("Variables")]
    private bool _isFoodGiving;

    private void Awake()
    {
        _waiter = transform.parent.parent.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (!_waiter.HasFoodOnHand)
        {
            ResetVariables();

            return RunToIdleState;
        }
        else
        {
            if (!_isFoodGiving)
            {
                _waiter.CurrentCustomer = _waiter.CurrentOrder.Customer;

                //siparis verme sesi oynat

                //yemegini ver
                _waiter.CurrentCustomer.MusteriyeYemekVer();

                //yemegi poola yolla

                //waiterin elindeki yemegi sil
                _waiter.HasFoodOnHand = false;
                HasFoodOnHand = false;

                _isFoodGiving = true;

                MoneyManager.Instance.AddMoney(_waiter.CurrentOrder.Machine.MachineData.FoodPrefab.GetComponent<Food>().Price);
            }


            return this;
        }
    }

    public void ResetVariables()
    {
        _isFoodGiving = false;

        _waiter.CurrentOrder = null;
        _waiter.CurrentCustomer = null;
    }
}
