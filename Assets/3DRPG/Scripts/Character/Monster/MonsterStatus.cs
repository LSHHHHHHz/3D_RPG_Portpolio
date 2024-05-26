using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterStatus : MonoBehaviour,IActor
{
    public PlayerData playerData { get; private set; }
    [SerializeField] private PlayerStatusUI playerStatusUI;
    private void Start()
    {
        InitializedStatus();
    }
    private void InitializedStatus()
    {
        playerData = CharacterData.instance.playerData;
        playerStatusUI.SetData(playerData);
    }
    public void ReceiveEvent(IEvent iEvent)
    {
        iEvent.ExcuteEvent(this);
    }
}
