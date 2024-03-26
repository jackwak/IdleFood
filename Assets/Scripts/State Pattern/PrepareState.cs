using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareState : State
{
    [Header("States")]
    public State RunToCustomerState;

    [Header("Transitions")]
    public bool IsFoodCompleted;

    [Header("References")]
    private Waiter _waiter;

    private void Awake()
    {
        _waiter = transform.root.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsFoodCompleted)
        {
            ResetVariables();
            OrderManager.Instance.SetMachineToAvailable(_waiter.CurrentOrder.Machine, _waiter.CurrentOrder.Food);

            return RunToCustomerState;
        }
        else
        {
            StartCoroutine(Prepare());

            return this;
        }
    }

    private void ResetVariables()
    {
        IsFoodCompleted = false;
    }

    private IEnumerator Prepare()
    {
        // progress bar

        //waiter anim

        float dispenceTime = _waiter.CurrentOrder.Machine.DispenseTime;
        yield return new WaitForSeconds(dispenceTime);

        //yemegi alma sesi

        //yemegi waiterin eline ver (makineden cek yemegi) yemegin pozisyonunu karakterimin eline esitle

        IsFoodCompleted = true;
        _waiter.HasFoodOnHand = true;
    }
}
