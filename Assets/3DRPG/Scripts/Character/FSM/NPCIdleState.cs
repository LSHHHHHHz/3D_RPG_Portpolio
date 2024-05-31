using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCIdleState : IState
{
    private readonly NPC character;
    private readonly Player player;
    private float originNPCmoveSpeed;

    public NPCIdleState(NPC character, Player player)
    {
        this.character = character;
        this.player = player;
    }
    public void Enter()
    {
        originNPCmoveSpeed = character.moveSpeed;
        character.moveSpeed = 0;
        
    }

    public void Exit()
    {
        character.moveSpeed = originNPCmoveSpeed;
    }

    public void Update()
    {
        Vector3 rotationDir = (player.transform.position - character.transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(rotationDir);
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, character.rotationSpeed * Time.deltaTime);
        
        if (player.isTalk) // 플레어와 대화를 하게 된다면을 조건문에 넣어야함
        {
            character.ChangeState(new NPCTalkState(character, player));            
        }
    }
}
