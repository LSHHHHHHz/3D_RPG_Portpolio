using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterAttackState : IState
{
    private readonly Monster monster;

    public MonsterAttackState(Monster character)
    {
        this.monster = character;
    }
    public void Enter()
    {
        monster.anim.SetBool("IsAttack", true); 
        monster.navMesh.isStopped= true;
    }

    public void Exit()
    {
        monster.anim.SetBool("IsAttack", false);
        monster.navMesh.isStopped = false;
    }

    public void Update()
    {
        if (monster.detectActor.closetActor != null && monster.detectActor.closetActor is Player player)
        {
            monster.transform.LookAt(player.transform);
        }
        else
        {
            monster.ChangeState(new MonsterIWalkState(monster));
        }
    }
}
