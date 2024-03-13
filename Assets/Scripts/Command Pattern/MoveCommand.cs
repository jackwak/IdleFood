using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : ICommand
{
    private Waiter _waiter;
    private Vector3 _position;

    public MoveCommand(Waiter waiter, Vector3 position)
    {
        _waiter = waiter;
        _position = position;
    }

    public void Execute()
    {
        NavMeshAgent agent = _waiter.Agent;

        agent.SetDestination(_position);
    }
}
