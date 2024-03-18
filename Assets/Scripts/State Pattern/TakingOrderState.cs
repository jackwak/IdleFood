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
                //sipari�i sipari� listine ekle

                //sipari� alma s�resi
                while (_passingTime < LevelManager.Instance.TakingOrderTime)
                {
                    _passingTime += Time.deltaTime;
                }

                //sipari� alma sesi

                //sipari�i al
                IsOrderTook = true;
            }
            //sipari� hangi makinenin kontrol eet

            //m�sait machine var m� bak

            return this;
        }
    }
}
