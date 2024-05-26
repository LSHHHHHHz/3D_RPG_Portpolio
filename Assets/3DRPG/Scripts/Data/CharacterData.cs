using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public static CharacterData _instance;
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
    public PlayerData playerData;
    public List<NormarMonsterData> normarMonster;
    public List<BossMonsterData> bossMonster;
    private CharacterData()
    {
        playerData = new PlayerData("ÀÌ½ÂÈÆ", "¾ÆÁ÷ ¸øÁ¤ÇÔ", 100, 100, 50, 50, 100, 0, 1, 100, 50);
    }
}
[System.Serializable]
public class PlayerData
{
    public string playerName { get; private set; }
    public string iconPath { get; private set; }
    public float maxHP { get; private set; }
    public float currentHP { get; private set; }
    public int lvUpHP { get; private set; }
    public float maxMP { get; private set; }
    public float currentMP { get; private set; }
    public int lvUpMP { get; private set; }
    public float maxExp { get; private set; }
    public float currentExp { get; private set; }
    public int playerLV { get; private set; }

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
        while (currentExp >= maxExp)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        playerLV++;
        currentExp -= maxExp;
        maxExp = NextLvExp();
        maxHP += lvUpHP;
        currentHP = maxHP;
        maxMP += lvUpMP;
        currentMP = maxMP;
    }
    private float NextLvExp()
    {
        return maxExp + 100;
    }
    public PlayerData(string playerName, string iconPath, int maxHP, int currentHP, int maxMP, int currentMP, int maxExp, int currentExp, int playerLV, int lvUpHP, int lvUpMP)
    {
        this.playerName = playerName;
        this.iconPath = iconPath;
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.maxMP = maxMP;
        this.currentMP = currentMP;
        this.maxExp = maxExp;
        this.currentExp = currentExp;
        this.playerLV = playerLV;
        this.lvUpHP = lvUpHP;
        this.lvUpMP = lvUpMP;
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
