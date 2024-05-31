using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterIdleState : IState
{
    private readonly Monster monster;

    public MonsterIdleState(Monster character)
    {
        this.monster = character;
    }
    public void Enter()
    {
        monster.anim.SetBool("IsWalk", false);
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if(monster.spawnerDetectActor!= null)
        {
            monster.fSMController.ChangeState(new MonsterIWalkState(monster));
        }
    }
}
