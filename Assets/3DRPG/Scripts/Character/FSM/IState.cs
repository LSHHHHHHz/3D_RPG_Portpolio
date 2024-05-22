using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Exit();
}
public interface ICharacterState
{
    FSMController fSMController { get; }
    Animator anim { get; }
    void ChangeState(IState newState);
}