using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveingNPC : NPC
{
    WarePoint warePoint;
    protected override void Awake()
    {
        base.Awake();
        warePoint = GetComponent<WarePoint>();        
    }
    protected override void Update()
    {
        base.Update();
        warePoint.SetMoveSpeedAndRotationSpeed(moveSpeed, rotationSpeed);
    }
    private void OnEnable()
    {
        ChangeState(new NPCWalkState(this));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ChangeState(new NPCLookPlayerState(this, player));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeState(new NPCWalkState(this));
        }
    }
}
