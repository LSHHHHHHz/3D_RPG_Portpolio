using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class MonsterData
{
    public List<string> monsterID;
    public List<MonsterStatusData> monsterStatusDatas;
    public List<MonsterProfileData> monsterProfileDatas;
    public List<MonsterRewardData> monsterRewardDatas;

    public MonsterData()
    {
        monsterID = new List<string>();
        monsterStatusDatas = new List<MonsterStatusData>();
        monsterProfileDatas= new List<MonsterProfileData>();
        monsterRewardDatas= new List<MonsterRewardData>();
    }
    public void AddMonster(string monsterName, MonsterStatusData statusData, MonsterProfileData profileData, MonsterRewardData rewardData)
    {
        monsterID.Add(monsterName);
        monsterStatusDatas.Add(statusData);
        monsterProfileDatas.Add(profileData);
        monsterRewardDatas.Add(rewardData);
    }
    public void InitializeMonsters()
    {
        for(int i = monsterID.Count-1; i>=0; i--)
        {
            monsterID.Remove(monsterID[i]);
            monsterStatusDatas.Remove(monsterStatusDatas[i]);
            monsterProfileDatas.Remove(monsterProfileDatas[i]);
            monsterRewardDatas.Remove(monsterRewardDatas[i]);
        }
        AddMonster("Monster1", new MonsterStatusData(100, 100, 0, 0, 10), new MonsterProfileData("Monster1", "아직"),
                              new MonsterRewardData(GameData.instance.staticGameItemData.portionDatas[0], 100, 50));

        AddMonster("Monster2", new MonsterStatusData(100, 100, 0, 0, 10), new MonsterProfileData("Monster2", "아직"),
                             new MonsterRewardData(GameData.instance.staticGameItemData.portionDatas[0], 100, 50));
        AddMonster("Monster3", new MonsterStatusData(100, 100, 0, 0, 10), new MonsterProfileData("Monster3", "아직"),
                           new MonsterRewardData(GameData.instance.staticGameItemData.portionDatas[0], 100, 50));
    }
}
[System.Serializable]
public class MonsterStatusData
{
   [SerializeField] public int maxHP;
    [SerializeField] public int currentHP;
    [SerializeField] public int maxMP;
    [SerializeField] public int currentMP;
    [SerializeField] public int damage;
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
    [SerializeField] public string monsterName;
    [SerializeField] public string prefabPath;
    public MonsterProfileData(string monsterName, string prefabPath)
    {
        this.monsterName = monsterName;
        this.prefabPath = prefabPath;
    }
}
[System.Serializable]
public class MonsterRewardData
{
    [SerializeField] public GameItemData rewardItem;
    [SerializeField] public int rewardCoin;
    [SerializeField] public int rewardExp;
    public MonsterRewardData(GameItemData rewardItem, int rewardCoin, int rewardExp)
    {
        this.rewardItem = rewardItem;
        this.rewardCoin = rewardCoin;
        this.rewardExp = rewardExp;
    }
}
