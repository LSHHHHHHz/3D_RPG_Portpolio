using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaticNPC : NPC
{
    private void OnEnable()
    {
        ChangeState(new NPCIdleState(this, player));
    }
}
