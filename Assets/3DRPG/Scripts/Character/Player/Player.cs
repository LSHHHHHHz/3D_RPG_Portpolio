using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IActor
{
    public bool isTalk = false;
    public GameObject scanObject { get; private set; }
    public PlayerStatusData playerStatusData { get; private set; }
    public PlayerProfileData playerProfileData { get; private set; }
    public PlayerCurrencyData playerCurrencyData { get; private set; }

    [SerializeField] PlayerUIManager playerStatusUI;
    private void Awake()
    {
        InitializedStatus();
    }

    private void Update()
    {
        if(scanObject != null && Input.GetButtonDown("Check"))
        {
            isTalk= true;
        }
    }
    private void InitializedStatus()
    {
        playerStatusData = CharacterData.instance.playerStatusData;
        playerProfileData = CharacterData.instance.playerProfileData;
        playerCurrencyData = CharacterData.instance.playerCurrencyData;
        playerStatusUI.SetData(playerStatusData);
        playerStatusUI.SetData(playerProfileData);
        playerStatusUI.SetData(playerCurrencyData);
    }
    public void ReceiveEvent(IEvent iEvent)
    {
        iEvent.ExcuteEvent(this);
        playerStatusUI.SetData(playerStatusData);
    }
    public void TakeDamage(int amount)
    {
        playerStatusData.StatusCurrentHP(-amount);
        playerStatusUI.SetData(playerStatusData);
    }
    public void RecoveryHP(int amount)
    {
        playerStatusData.StatusCurrentHP(amount);
        playerStatusUI.SetData(playerStatusData);
    }
    public void UseMP(int amount)
    {
        playerStatusData.StatusCurrentMP(-amount);
        playerStatusUI.SetData(playerStatusData);
    }
    public void RecoveryMP(int amount)
    {
        playerStatusData.StatusCurrentMP(amount);
        playerStatusUI.SetData(playerStatusData);
    }
    public void GainExperience(int expAmount)
    {
        playerStatusData.AddExp(expAmount);
        playerStatusUI.SetData(playerStatusData);
    }
    public void CheckExpLV()
    {
        if(playerStatusData.currentExp <playerStatusData.maxExp)
        {
            playerStatusData.currentExp -= playerStatusData.maxExp;
            playerStatusData.playerLV++;
            playerStatusData.maxExp += playerStatusData.lvUpEXP;
            playerStatusData.maxHP += playerStatusData.lvUpHP;
            playerStatusData.currentHP = playerStatusData.maxHP;
            playerStatusData.maxMP += playerStatusData.lvUpMP;
            playerStatusData.currentMP = playerStatusData.maxMP;
        }
        playerStatusUI.SetData(playerStatusData);
    }
    public void GetCoin(int getCoin)
    {
        playerCurrencyData.GetCoin(getCoin);
        playerStatusUI.SetData(playerCurrencyData);
    }
    public void ConsumeCoin(int consumCoin)
    {
        playerCurrencyData.ConsumeCoint(consumCoin);
        playerStatusUI.SetData(playerCurrencyData);
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
