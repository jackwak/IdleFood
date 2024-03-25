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
    private float _passingTime;
    private bool _isOrderTook;

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
                //sipari�i sipari� listine ekle

                //sipari� alma s�resi �ENUMERATORLE YAP
                while (_passingTime < LevelManager.Instance.TakingOrderTime)
                {
                    _passingTime += Time.deltaTime;
                }

                //sipari� alma sesi

                //sipari�i al
                //customer managerdan sipari�i al ekle
                _isOrderTook = true;
            }

            return this;
        }
    }

    public void ResetVariables()
    {
        IsOrderTook = false;

        _passingTime = 0f;
    }
}
