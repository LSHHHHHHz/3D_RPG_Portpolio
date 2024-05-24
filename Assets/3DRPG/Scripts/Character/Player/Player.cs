using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ICharacterState
{
    public bool isTalk =false;
    GameObject scanObject;
    public FSMController fSMController => throw new System.NotImplementedException();

    public Animator anim => throw new System.NotImplementedException();

    public void ChangeState(IState newState)
    {
        throw new System.NotImplementedException();
    }
    private void Update()
    {
        if(scanObject != null && Input.GetButtonDown("Check"))
        {
            isTalk= true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            scanObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            scanObject = null;
        }
    }
}