using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterStatus : MonoBehaviour,IActor
{
    public void ReceiveEvent(IEvent iEvent)
    {
        iEvent.ExcuteEvent(this);
    }
}
