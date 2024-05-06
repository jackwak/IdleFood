using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOrderState : State
{
    [Header("States")]
    public State RunToIdleState;

    [Header("Transitions")]
    public bool IsOrderTook;

    [Header("Variables")]
    //ismi degis
    private bool _isOrderTook;
    private Waiter _waiter;

    private void Awake()
    {
        _waiter = transform.parent.parent.GetComponent<Waiter>();
    }

    public override State RunCurrentState()
    {
        if (IsOrderTook)
        {
            ResetVariables();

            return RunToIdleState;
        }
        else
        {
            if (!_isOrderTook)
            {
                //siparisi al
                StartCoroutine(TakingOrder());

                _isOrderTook = true;
            }

            return this;
        }
    }

    public void ResetVariables()
    {
        _isOrderTook = false;
        IsOrderTook = false;
    }

    IEnumerator TakingOrder()
    {
        // progress bar yap

        float takingOrderTime = LevelManager.Instance.TakingOrderTime;

        _waiter.ProgressBarController.StartProgressBar(takingOrderTime);

        yield return new WaitForSeconds(takingOrderTime);

        //siparis alma sesi

        //siparisi siparis listine ekle
        int foodCount = _waiter.CurrentCustomer.FoodCount;

        _waiter.CurrentCustomer.ShowBubble();

        for (int i = 0; i < foodCount; i++)
        {
            OrderManager.Instance.Customers.Add(_waiter.CurrentCustomer);
            OrderManager.Instance.Foods.Add(_waiter.CurrentCustomer.OrderedFood);

            //OrderManager.Instance.AddOrder(_waiter.CurrentCustomer);
        }

        _waiter.CurrentCustomer = null;

        IsOrderTook = true;
    }
}
