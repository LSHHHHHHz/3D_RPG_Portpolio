using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShopNPC : NPC
{
    public GameObject shopPopup;
    private void OnEnable()
    {
        ChangeState(new NPCIdleState(this));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            checkPlayer = true;
            ChangeState(new NPCLookPlayerState(this,player));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeState(new NPCIdleState(this));
        }
    }
}
