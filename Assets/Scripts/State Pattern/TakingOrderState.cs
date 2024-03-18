using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOrderState : State
{
    [Header("States")]
    public State RunToIdleState;

    [Header("Transitions")]
    public bool IsOrderTook;
    public bool HasAvailableMachine;

    [Header("Variables")]
    private float _passingTime;

    public override State RunCurrentState()
    {
        if (IsOrderTook && !HasAvailableMachine)
        {
            

            return RunToIdleState;
        }
        else
        {
            if (!IsOrderTook)
            {
                //sipariþi sipariþ listine ekle

                //sipariþ alma süresi ÝENUMERATORLE YAP
                while (_passingTime < LevelManager.Instance.TakingOrderTime)
                {
                    _passingTime += Time.deltaTime;
                }

                //sipariþ alma sesi

                //sipariþi al
                //customer managerdan sipariþi al ekle
                IsOrderTook = true;
            }
            //sipariþ hangi makinenin kontrol eet

            //müsait machine var mý bak

            return this;
        }
    }

    public void ResetVariables()
    {
        IsOrderTook = false;
        HasAvailableMachine = false;

        _passingTime = 0f;
    }
}
