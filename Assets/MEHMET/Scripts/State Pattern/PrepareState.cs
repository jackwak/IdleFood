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
        _waiter = transform.parent.parent.GetComponent<Waiter>();
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
        // start machine anim
        Order order = _waiter.CurrentOrder;
        Machine machine = order.Machine;
        machine.Animator.SetBool("IsPreparing", true);

        // show preparing food
        StartCoroutine(machine.ShowPreparingFood());

        //waiter anim

        float dispenceTime = machine.MachineData.DispenseTime;

        // progress bar
        _waiter.ProgressBarController.StartProgressBar(dispenceTime);

        yield return new WaitForSeconds(dispenceTime);

        // finish machine anim
        machine.Animator.SetBool("IsPreparing", false);

        //yemegi alma sesi

        //yemegi waiterin eline ver (makineden cek yemegi) yemegin pozisyonunu karakterimin eline esitle (getfood yap ve posizyonunu waiter�n food posa ekle

        IsFoodCompleted = true;
        _waiter.HasFoodOnHand = true;
    }
}