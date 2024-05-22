using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, ICharacterState
{
    public FSMController fSMController { get; private set; }
    public Animator anim { get; private set; }
    bool isPlayerInTrigger = false;
    private void Awake()
    {
        fSMController= GetComponent<FSMController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        fSMController.Update();
    }
    public void ChangeState(IState newState)
    {
        fSMController.ChangeState(newState);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            ChangeState(new IdleState(this));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
