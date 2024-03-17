using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFoodCommand : ICommand
{
    private Waiter _waiter;


    public GiveFoodCommand(Waiter waiter)
    {
        _waiter = waiter;
    }

    public void Execute()
    {
        // yapýlýcak þeyler
    }
}
