using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WalkState : IState
{
    private readonly ICharacterState character;

    public WalkState(ICharacterState character)
    {
        this.character = character;
    }

    public void Enter( )
    {
        character.anim.SetBool("IsWalk", true);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
