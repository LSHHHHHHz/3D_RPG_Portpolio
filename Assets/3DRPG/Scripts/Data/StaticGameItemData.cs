using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGameItemData
{
    public List<PortionData> portionDatas;
    public List<EquipData> equipDatas;
    public List<SkillData> skillDatas;
    public StaticGameItemData()
    {
        portionDatas = new List<PortionData> {
            new PortionData("Portion/HP1", "기초 HP 포션", "체력이 100만큼 회복됩니다.",ItemType.Portion,100,0, 5,100,1),
            new PortionData("Portion/HP2", "기본 HP 포션" ,"체력이 300만큼 회복됩니다.", ItemType.Portion,300,0,5,300,2),
            new PortionData("Portion/HP3", "중급 HP 포션", "체력이 500만큼 회복됩니다.",ItemType.Portion,500,0,5,500,3),
            new PortionData("Portion/HP4", "고급 HP 포션", "체력이 1000만큼 회복됩니다.",ItemType.Portion,1000,0,5,1000,4),
            new PortionData("Portion/MP1", "기초 MP 포션", "마력이 10만큼 회복됩니다.",ItemType.Portion,0,10,5,100,1),
            new PortionData("Portion/MP2", "기본 MP 포션", "마력이 30만큼 회복됩니다.",ItemType.Portion,0,30,5,300,2),
            new PortionData("Portion/MP3", "중급 MP 포션", "마력이 50만큼 회복됩니다.",ItemType.Portion,0,50,5,500,3),
            new PortionData("Portion/MP4", "고급 MP 포션", "마력이 100만큼 회복됩니다.",ItemType.Portion,0,100,5,1000,4) };
        equipDatas = new List<EquipData> {
            new EquipData("Weapon/Sword1", "기초 무기","공격력 100을 증가시킵니다.",ItemType.Weapon,100,0, 100,0,1),
            new EquipData("Weapon/Sword2", "기본 무기","공격력 200을 증가시킵니다.",ItemType.Weapon,200,0, 200,1,2),
            new EquipData("Weapon/Sword3", "중급 무기","공격력 300을 증가시킵니다.",ItemType.Weapon,300,0, 300,2,3),
            new EquipData("Weapon/Sword4", "고급 무기","공격력 400을 증가시킵니다.",ItemType.Weapon,400,0, 400,3,4),
            new EquipData("Weapon/Shield1", "기초 방패","체력 100을 증가시킵니다.",ItemType.Shield,0,100, 100,0,1),
            new EquipData("Weapon/Shield2", "기본 방패","체력 200을 증가시킵니다.",ItemType.Shield,0,200, 200,1,2),
            new EquipData("Weapon/Shield3", "중급 방패","체력 300을 증가시킵니다.",ItemType.Shield,0,300, 300,2,3),
            new EquipData("Weapon/Shield4", "고급 방패","체력 400을 증가시킵니다.",ItemType.Shield,0,400, 400,3,4)
        };
        skillDatas = new List<SkillData> {
            new SkillData("SkillIcon/Skill1", "벽력일섬", " 20거리 내에 있는 적을 향해 순식간에 이동하여 적의 급소를 벤다.\n 쿨다운 10초", ItemType.Skill,1000,10,10,"SkillIcon/SkillPrefab/EffectSkill1",1),
            new SkillData("SkillIcon/Skill2", "원기옥", " 응축된 힘으로 적을 증발시킨다..\n 쿨다운 10초", ItemType.Skill,1000,10,10,"SkillIcon/SkillPrefab/EffectSkill2",2),
            new SkillData("SkillIcon/Skill3", "데스빔", " 범위 내 적에게 무작위로 레이저를 발사한다. 이후 적에게 적중하면 큰 폭팔이 발생한다.\n 쿨다운 10초", ItemType.Skill,100,10,10,"SkillIcon/SkillPrefab/EffectSkill3",3),
            new SkillData("SkillIcon/Skill4", "크래쉬", " 범위 내에 모든 적을 공격한다.\n 쿨다운 10초", ItemType.Skill,100,10,10,"SkillIcon/SkillPrefab/EffectSkill4",4),
            new SkillData("SkillIcon/Skill5", "유성", " 하늘에서 10개의 유성이 떨어진다.\n 쿨다운 10초", ItemType.Skill,1000,10,10,"",5),
            new SkillData("SkillIcon/Skill6", "이모탈", " 이동속도를 크게 증가시킨다.\n 쿨다운 10초", ItemType.Skill,1000,10,10,"",6),
            new SkillData("SkillIcon/Skill7", "쿠로", " 체력을 모두 회복한다.\n 쿨다운 10초", ItemType.Skill,1000,10,10,"",7),

        };
    }
}
[System.Serializable]
public class GameItemData
{
    public string iconPath;
    public string name;
    public string description;
    public ItemType type;
    public int coolDown;
    public int requiredLV;
}
[System.Serializable]
public class PortionData : GameItemData
{
    public int hpRecovery;
    public int mpRecovery;
    public int itemPrice;
    public PortionData(string iconPath, string itemName, string itemDescription, ItemType type, int hpRecovery, int mpRecovery, int coolDown, int itemPrice, int requiredLV)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.hpRecovery = hpRecovery;
        this.mpRecovery = mpRecovery;
        this.coolDown = coolDown;
        this.itemPrice = itemPrice;
        this.requiredLV = requiredLV;
    }
}
[System.Serializable]
public class EquipData : GameItemData
{
    public int addAttack;
    public int addHp;
    public int itemNum;
    public int itemPrice;
    public EquipData(string iconPath, string itemName, string itemDescription, ItemType type, int addAttack, int addHp, int itemPrice, int itemNum, int requiredLV)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.addAttack = addAttack;
        this.addHp = addHp;
        this.itemPrice = itemPrice;
        this.itemNum = itemNum;
        this.requiredLV = requiredLV;
    }
}
[System.Serializable]
public class SkillData : GameItemData
{
    public int damage;
    public int consumMP;
    public string prefabPath;
    public SkillData(string iconPath, string itemName, string itemDescription, ItemType type, int damage, int coolDown, int consumMP, string prefabPath, int requiredLV)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.damage = damage;
        this.coolDown = coolDown;
        this.consumMP = consumMP;
        this.prefabPath = prefabPath;
        this.requiredLV = requiredLV;
    }
}