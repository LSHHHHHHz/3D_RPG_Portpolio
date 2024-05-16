using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameItemData
{
    public string iconPath;
    public string name;
    public string description;
    public string type;
}
[System.Serializable]
public class PortionData : GameItemData
{
    public int hpRecovery;
    public int mpRecovery;
    public int coolDown;
    public int itemPrice;
    public PortionData(string iconPath, string itemName, string itemDescription, string type, int hpRecovery, int mpRecovery, int coolDown, int itemPrice)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.hpRecovery = hpRecovery;
        this.mpRecovery = mpRecovery;
        this.coolDown = coolDown;
        this.itemPrice = itemPrice;
    }
}
[System.Serializable]
public class EquipData : GameItemData
{
    public int addAttack;
    public int addHp;
    public int itemNum;
    public int itemPrice;
    public EquipData(string iconPath, string itemName, string itemDescription, string type, int addAttack, int addHp, int itemPrice, int itemNum)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.addAttack = addAttack;
        this.addHp = addHp;
        this.itemPrice = itemPrice;
        this.itemNum = itemNum;
    }
}
[System.Serializable]
public class SkillData : GameItemData
{
    public int damage;
    public int coolDown;
    public int consumMP;
    public string prefabPath;
    public SkillData(string iconPath, string itemName, string itemDescription, string type, int damage, int coolDown, int consumMP, string prefabPath)
    {
        this.iconPath = iconPath;
        this.name = itemName;
        this.description = itemDescription;
        this.type = type;
        this.damage = damage;
        this.coolDown = coolDown;
        this.consumMP = consumMP;
        this.prefabPath = prefabPath;
    }
}