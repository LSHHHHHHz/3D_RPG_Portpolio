using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    private static CharacterData _instance;
    public static CharacterData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CharacterData();
            }
            return _instance;
        }
    }
    public PlayerStatusData playerStatusData;
    public PlayerProfileData playerProfileData;
    public PlayerCurrencyData playerCurrencyData;
    public List<NormarMonsterData> normarMonsters;
    public List<BossMonsterData> bossMonsters;
    public CharacterData()
    {
        playerStatusData = new PlayerStatusData(100, 100, 50, 50, 100, 0, 1, 100, 50,100);
        playerProfileData = new PlayerProfileData("이승훈", "아직");
        playerCurrencyData = new PlayerCurrencyData(5000);
    }  
}
[System.Serializable]
public class PlayerStatusData
{
    //PlayerStatusUI에서 필요하기 때문에 private를 할 수가 없음
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

    public void AddMaxHP(int amount)
    {
        maxHP += amount;
    }
    public void StatusCurrentHP(int maxHP)
    {
        currentHP += maxHP;
    }
    public void AddMaxMP(int amount)
    {
        maxMP += amount;
    }
    public void StatusCurrentMP(int maxMP)
    {
        currentMP += maxMP;
    }
    public void AddExp(int amount)
    {
        currentExp += amount;
    }
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
[System.Serializable]
public class MonsterData
{
    public string monsterName;
    public string iconPath;
    public int maxHP;
    public int expAmount;
    public int damage;
}
[System.Serializable]
public class NormarMonsterData : MonsterData
{
    public NormarMonsterData(string monsterName, string iconPath, int maxHP, int exp, int damage)
    {
        this.monsterName = monsterName;
        this.iconPath = iconPath;
        this.maxHP = maxHP;
        this.expAmount = exp;
        this.damage = damage;
    }
}
[System.Serializable]
public class BossMonsterData : MonsterData
{
    public BossMonsterData(string monsterName, string iconPath, int maxHP, int exp, int damage)
    {
        this.monsterName = monsterName;
        this.iconPath = iconPath;
        this.maxHP = maxHP;
        this.expAmount = exp;
        this.damage = damage;
    }
}
