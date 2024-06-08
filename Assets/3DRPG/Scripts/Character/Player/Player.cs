using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IActor
{
    public static Player instance;
    public bool isTalk = false;
    public GameObject scanObject { get; private set; }
    public PlayerStatusData playerStatusData { get; private set; }
    public PlayerProfileData playerProfileData { get; private set; }
    public PlayerCurrencyData playerCurrencyData { get; private set; }
    public ISlotData quickSkillSlotData { get; private set; }
    public ISlotData quickPortionSlotData { get; private set; }

    [SerializeField] PlayerUIManager playerStatusUI;
    private void Awake()
    {
        instance = this;
        InitializedStatus();
    }
    private void Update()
    {
        if(scanObject != null && Input.GetButtonDown("Check"))
        {
            isTalk= true;
            if(scanObject.GetComponent<NPC>() is ShopNPC shopNPC)
            {
                Instantiate(shopNPC.shopPopup, TransformFactory.instance.shopPopupTransform);
            }
        }
    }
    private void InitializedStatus()
    {
        playerStatusData = GameData.instance.playerData.playerStatusData;
        playerProfileData = GameData.instance.playerData.playerProfileData;
        playerCurrencyData = GameData.instance.playerData.playerCurrencyData;
        quickSkillSlotData = GameData.instance.quickSkillSlotData;
        quickPortionSlotData = GameData.instance.quickPortionSlotData;
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
        playerStatusData.currentHP -=amount;
        playerStatusUI.SetData(playerStatusData);
    }
    public void RecoveryHP(int amount)
    {
        playerStatusData.currentHP += amount;
        playerStatusUI.SetData(playerStatusData);
    }
    public void UseMP(int amount)
    {
        playerStatusData.currentMP -=amount;
        playerStatusUI.SetData(playerStatusData);
    }
    public void RecoveryMP(int amount)
    {
        playerStatusData.currentMP += amount;
        playerStatusUI.SetData(playerStatusData);
    }
    public void GainExperience(int expAmount)
    {
        playerStatusData.currentExp += expAmount;
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
    public void ClickQuickSlot(ISlotData slotData,DropSlotUI itemSlot, int index)
    {
        if(slotData is QuickSkillSlotData quickSkill)
        {

        }
        if(slotData is QuickPortionSlotData quickPortion && !itemSlot.isActiveCoolTime)
        {
            if(quickPortion.slotDatas[index].count>0)
            {
                itemSlot.CoolDown(quickPortion.slotDatas[index].item.coolDown);
                quickPortion.slotDatas[index].UseItem(quickPortion.slotDatas[index]);
            }
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
