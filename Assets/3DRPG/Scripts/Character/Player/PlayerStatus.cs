using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IActor
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
        playerStatusUI.SetData(playerData);
    }
    public void TakeDamage(int amount)
    {
        playerData.StatusCurrentHP(-amount);
        playerStatusUI.SetData(playerData);
    }
    public void RecoveryHP(int amount)
    {
        playerData.StatusCurrentHP(amount);
        playerStatusUI.SetData(playerData);
    }
    public void ExcuteSkill(int amount)
    {
        playerData.StatusCurrentMP(-amount);
        playerStatusUI.SetData(playerData);
    }
    public void RecoveryMP(int amount)
    {
        playerData.StatusCurrentMP(amount);
        playerStatusUI.SetData(playerData);
    }
    public void GainExperience(int amount)
    {
        playerData.AddExp(amount);
        playerStatusUI.SetData(playerData);
    }
}
