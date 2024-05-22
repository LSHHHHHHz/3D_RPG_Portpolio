using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    public Animator anim;
    IState currentState;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        currentState?.Update();
    }
    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}