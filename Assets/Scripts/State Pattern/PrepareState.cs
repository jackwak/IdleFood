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
        float dispenceTime = _waiter.CurrentOrder.Machine.DispenseTime;
        yield return new WaitForSeconds(dispenceTime);

        IsFoodCompleted = true;
    }
}
