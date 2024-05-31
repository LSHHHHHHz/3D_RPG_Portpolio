using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
public class NPCTalkState : IState
{
    private readonly NPC character;
    private readonly Player player;

    public NPCTalkState(NPC character, Player player)
    {
        this.character = character;
        this.player = player;
    }
    public void Enter( )
    {
        character.anim.SetTrigger("DoTalk");
    }

    public void Exit()
    {
        character.anim.ResetTrigger("DoTalk");
    }

    public void Update()
    {
        //대화 팝업창이 모두 닫혔을 때 Idle 상태로 변환시켜야 할 듯.
        AnimatorStateInfo stateInfo = character.anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("DoTalk") && stateInfo.normalizedTime >= 1.0f)
        {
            player.isTalk = false;
            character.ChangeState(new NPCIdleState(character, player));
        }
    }
}
