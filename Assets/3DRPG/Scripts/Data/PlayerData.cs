using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerStatusData playerStatusData;
    public PlayerProfileData playerProfileData;
    public PlayerCurrencyData playerCurrencyData;
    public PlayerData()
    {
        playerStatusData = new PlayerStatusData(100, 100, 50, 50, 100, 0, 1, 100, 50,100);
        playerProfileData = new PlayerProfileData("ÀÌ½ÂÈÆ", "¾ÆÁ÷");
        playerCurrencyData = new PlayerCurrencyData(5000);
    }  
}
[System.Serializable]
public class PlayerStatusData
{
    [SerializeField] public float maxHP;
    [SerializeField] public float currentHP;
    [SerializeField] public float maxMP;
    [SerializeField] public float currentMP;
    [SerializeField] public float maxExp;
    [SerializeField] public float currentExp;
    [SerializeField] public int playerLV;

    [SerializeField] public int lvUpHP;
    [SerializeField] public int lvUpMP;
    [SerializeField] public int lvUpEXP;

    public PlayerStatusData(int maxHP, int currentHP, int maxMP, int currentMP, int maxExp, int currentExp, int playerLV, int lvUpHP, int lvUpMP, int lvUpEXP)
    {
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.maxMP = maxMP;
        this.currentMP = currentMP;
        this.maxExp = maxExp;
        this.currentExp = currentExp;
        this.playerLV = playerLV;
        this.lvUpHP = lvUpHP;
        this.lvUpMP = lvUpMP;
        this.lvUpEXP = lvUpEXP;
    }
}
public class PlayerProfileData
{
    [SerializeField] public string playerName;
    [SerializeField] public string iconPath;

    public void ChangeName(string name)
    {
        playerName = name;
    }
    public void ChangeIconPath(string path)
    {
        iconPath = path;
    }

    public PlayerProfileData(string playerName, string iconPath)
    {
        this.playerName = playerName;
        this.iconPath = iconPath;
    }
}
public class PlayerCurrencyData
{
    [SerializeField]public int coin;
    public void GetCoin(int getCoin)
    {
        this.coin += getCoin;
    }
    public void ConsumeCoint(int consum)
    {
        this.coin -= consum;
    }
    public PlayerCurrencyData(int coin)
    {
        this.coin = coin;
    }
}
