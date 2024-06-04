using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterData
{
    public Dictionary<string, MonsterStatusData> monsterStatusDataDic;
    public Dictionary<string, MonsterProfileData> monsterProfileDataDic;
    public Dictionary<string, MonsterRewardData> monsterRewardDataDic;

    public MonsterData()
    {
        monsterStatusDataDic = new Dictionary<string, MonsterStatusData>();
        monsterProfileDataDic = new Dictionary<string, MonsterProfileData>();
        monsterRewardDataDic = new Dictionary<string, MonsterRewardData>();

        //AddMonster("Monster1", new MonsterStatusData(100, 100, 0, 0, 10), new MonsterProfileData("Monster1", "¾ÆÁ÷"), 
        //                       new MonsterRewardData(GameData.instance.staticGameItemData.portionDatas[0], 100, 50));
    }
    public void AddMonster(string monsterName, MonsterStatusData statusData, MonsterProfileData profileData, MonsterRewardData rewardData)
    {
        monsterStatusDataDic[monsterName] = statusData;
        monsterProfileDataDic[monsterName] = profileData;
        monsterRewardDataDic[monsterName] = rewardData;
    }
}
[System.Serializable]
public class MonsterStatusData
{
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;
    public int damage;
    public MonsterStatusData(int maxHP, int currentHP, int maxMP, int currentMP, int damage)
    {
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.maxMP = maxMP;
        this.currentMP = currentMP;
        this.damage = damage;
    }
}
[System.Serializable]
public class MonsterProfileData
{
    public string monsterName;
    public string prefabPath;
    public MonsterProfileData(string monsterName, string prefabPath)
    {
        this.monsterName = monsterName;
        this.prefabPath = prefabPath;
    }
}
public class MonsterRewardData
{
    public GameItemData rewardItem;
    public int rewardCoin;
    public int rewardExp;
    public MonsterRewardData(GameItemData rewardItem, int rewardCoin, int rewardExp)
    {
        this.rewardItem = rewardItem;
        this.rewardCoin = rewardCoin;
        this.rewardExp = rewardExp;
    }
}
