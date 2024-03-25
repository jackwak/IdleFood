using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}
