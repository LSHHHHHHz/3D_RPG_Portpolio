using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] Image playerImage;
    [SerializeField] Image hpBar;
    [SerializeField] Image mpBar;
    [SerializeField] Image expBar;
    [SerializeField] Text playerNameText;
    [SerializeField] Text hpText;
    [SerializeField] Text mpText;
    [SerializeField] Text playerLVText;

    public void SetData(PlayerData playerData)
    {
        playerImage.sprite = Resources.Load<Sprite>(playerData.iconPath);
        hpBar.fillAmount = playerData.currentHP / playerData.maxHP;
        mpBar.fillAmount = playerData.currentMP / playerData.maxMP;
        expBar.fillAmount = playerData.currentExp/ playerData.maxExp;
        playerNameText.text = playerData.playerName;
        hpText.text = playerData.currentHP + " / " + playerData.maxHP;
        mpText.text = playerData.currentMP + " / " + playerData.maxMP;
        playerLVText.text = "LV " + playerData.playerLV;
    }
}
