using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IdleState : IState
{
    private readonly ICharacterState character;

    public IdleState(ICharacterState character)
    {
        this.character = character;
    }
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
    }
}
