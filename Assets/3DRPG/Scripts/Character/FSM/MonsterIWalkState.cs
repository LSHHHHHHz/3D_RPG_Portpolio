using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterIWalkState : IState
{
    private readonly Monster monster;
    Vector3 targetPos;

    public MonsterIWalkState(Monster character)
    {
        this.monster = character;
    }
    public void Enter()
    {
        monster.anim.SetBool("IsWalk", true);
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if(monster.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }
        if (monster.spawnerDetectActor != null)
        {
            if (monster.spawnerDetectActor is Player player)
            {
                monster.navMesh.SetDestination(player.transform.position);
                monster.transform.LookAt(player.transform.position);
                targetPos = player.transform.position;
                if(monster.detectActor.closetActor != null)
                {
                    monster.ChangeState(new MonsterAttackState(monster));
                }
            }
        }
        else
        {
            float distanceToOrigin = Vector3.Distance(monster.transform.position, monster.originPos);
            if (distanceToOrigin > 1.6f)
            {
                monster.navMesh.SetDestination(monster.originPos);
                monster.transform.LookAt(monster.originPos);
            }
            else
            {
                monster.ChangeState(new MonsterIdleState(monster));
            }
        }

    }
}

