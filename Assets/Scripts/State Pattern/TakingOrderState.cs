using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOrderState : State
{
    public State RunToIdleState;
    public bool IsOrderTook;
    public bool HasAvailableMachine;

    [Header("Variables")]
    private float _passingTime;

    public override State RunCurrentState()
    {
        if (IsOrderTook && !HasAvailableMachine)
        {
            IsOrderTook = false;
            _passingTime = 0f;

            return RunToIdleState;
        }
        else
        {
            if (!IsOrderTook)
            {
                //sipariþi sipariþ listine ekle

                //sipariþ alma süresi
                while (_passingTime < LevelManager.Instance.TakingOrderTime)
                {
                    _passingTime += Time.deltaTime;
                }

                //sipariþ alma sesi

                //sipariþi al
                IsOrderTook = true;
            }
            //sipariþ hangi makinenin kontrol eet

            //müsait machine var mý bak

            return this;
        }
    }
}
