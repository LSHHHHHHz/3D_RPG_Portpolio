using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCWalkState : IState
{
    private readonly NPC character;

    public NPCWalkState(NPC character)
    {
        this.character = character;
    }

    public void Enter( )
    {
        character.anim.SetBool("IsWalk", true);
    }

    public void Exit()
    {
        character.anim.SetBool("IsWalk", false);
    }

    public void Update()
    {
    }
}
