using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] Image playerImage;
    [SerializeField] Image hpBar;
    [SerializeField] Image mpBar;
    [SerializeField] Image expBar;
    [SerializeField] Text playerNameText;
    [SerializeField] Text hpText;
    [SerializeField] Text mpText;
    [SerializeField] Text playerLVText;
    [SerializeField] Text playerHasCoin;

    public void SetData(PlayerStatusData playerStatusData)
    {
        hpBar.fillAmount = playerStatusData.currentHP / playerStatusData.maxHP;
        mpBar.fillAmount = playerStatusData.currentMP / playerStatusData.maxMP;
        expBar.fillAmount = playerStatusData.currentExp/ playerStatusData.maxExp;
        hpText.text = playerStatusData.currentHP + " / " + playerStatusData.maxHP;
        mpText.text = playerStatusData.currentMP + " / " + playerStatusData.maxMP;
        playerLVText.text = "LV " + playerStatusData.playerLV;
    }
    public void SetData(PlayerProfileData playerProfileData)
    {
        playerImage.sprite = Resources.Load<Sprite>(playerProfileData.iconPath);
        playerNameText.text = playerProfileData.playerName;
    }
    public void SetData(PlayerCurrencyData playerCurrency)
    {
        playerHasCoin.text = playerCurrency.coin.ToString();
    }
}
