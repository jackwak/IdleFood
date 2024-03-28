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

    [Header("Variables")]
    private bool _isPreparing;

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
            if (!_isPreparing)
            {
                StartCoroutine(Prepare());
                _isPreparing = true;
            }

            return this;
        }
    }

    private void ResetVariables()
    {
        IsFoodCompleted = false;
        _isPreparing = false;
    }

    private IEnumerator Prepare()
    {


        //waiter anim

        float dispenceTime = _waiter.CurrentOrder.Machine.DispenseTime;

        // progress bar
        _waiter.ProgressBarController.StartProgressBar(dispenceTime);

        yield return new WaitForSeconds(dispenceTime);

        //yemegi alma sesi

        //yemegi waiterin eline ver (makineden cek yemegi) yemegin pozisyonunu karakterimin eline esitle

        IsFoodCompleted = true;
        _waiter.HasFoodOnHand = true;
    }
}
