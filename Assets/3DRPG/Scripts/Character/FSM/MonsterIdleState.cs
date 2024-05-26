using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterIdleState : IState
{
    private readonly Monster monster;
    private readonly Player player;
    private float originNPCmoveSpeed;

    public MonsterIdleState(Monster character, Player player)
    {
        this.monster = character;
        this.player = player;
    }
    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
