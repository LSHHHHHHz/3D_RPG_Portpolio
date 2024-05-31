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
    public PlayerData playerData;
    public List<NormarMonsterData> normarMonsters;
    public List<BossMonsterData> bossMonsters;
    public CharacterData()
    {
        playerData = new PlayerData("이승훈", "아직 못정함", 100, 100, 50, 50, 100, 0, 1, 100, 50);
    }  
}
[System.Serializable]
public class PlayerData
{
    [SerializeField] public string playerName; //status에 있으면 이상함
    [SerializeField] public string iconPath;
    [SerializeField] public float maxHP;
    [SerializeField] public float currentHP;
    [SerializeField] public int lvUpHP;
    [SerializeField] public float maxMP;
    [SerializeField] public float currentMP;
    [SerializeField] public int lvUpMP;
    [SerializeField] public float maxExp;
    [SerializeField] public float currentExp;
    [SerializeField] public int playerLV;

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
    private void LevelUp() //LV업 상태는 데이터에서 관리X LV만 관리하면됨
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
