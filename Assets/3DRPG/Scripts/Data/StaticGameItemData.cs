using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGameItemData
{
    private static StaticGameItemData _instance;
    public static StaticGameItemData instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new StaticGameItemData();
            }
            return _instance;            
        }
    }
    public List<PortionData> portionDatas;
    public List<EquipData> equipDatas;
    public List<SkillData> skillDatas;
    public StaticGameItemData()
    {
        portionDatas = new List<PortionData> {
            new PortionData("Portion/HP1", "���� HP ����", "ü���� 100��ŭ ȸ���˴ϴ�.","Portion",100,0, 5,100,1),
            new PortionData("Portion/HP2", "�⺻ HP ����" ,"ü���� 300��ŭ ȸ���˴ϴ�.", "Portion",300,0,5,300,2),
            new PortionData("Portion/HP3", "�߱� HP ����", "ü���� 500��ŭ ȸ���˴ϴ�.","Portion",500,0,5,500,3),
            new PortionData("Portion/HP4", "��� HP ����", "ü���� 1000��ŭ ȸ���˴ϴ�.","Portion",1000,0,5,1000,4),
            new PortionData("Portion/MP1", "���� MP ����", "������ 10��ŭ ȸ���˴ϴ�.","Portion",0,10,5,100,1),
            new PortionData("Portion/MP2", "�⺻ MP ����", "������ 30��ŭ ȸ���˴ϴ�.","Portion",0,30,5,300,2),
            new PortionData("Portion/MP3", "�߱� MP ����", "������ 50��ŭ ȸ���˴ϴ�.","Portion",0,50,5,500,3),
            new PortionData("Portion/MP4", "��� MP ����", "������ 100��ŭ ȸ���˴ϴ�.","Portion",0,100,5,1000,4) };
        equipDatas = new List<EquipData> {
            new EquipData("Weapon/Sword1", "���� ����","���ݷ� 100�� ������ŵ�ϴ�.","Equip",100,0, 100,0,1),
            new EquipData("Weapon/Sword2", "�⺻ ����","���ݷ� 200�� ������ŵ�ϴ�.","Equip",200,0, 200,1,2),
            new EquipData("Weapon/Sword3", "�߱� ����","���ݷ� 300�� ������ŵ�ϴ�.","Equip",300,0, 300,2,3),
            new EquipData("Weapon/Sword4", "��� ����","���ݷ� 400�� ������ŵ�ϴ�.","Equip",400,0, 400,3,4),
            new EquipData("Weapon/Shield1", "���� ����","ü�� 100�� ������ŵ�ϴ�.","Equip",0,100, 100,0,1),
            new EquipData("Weapon/Shield2", "�⺻ ����","ü�� 200�� ������ŵ�ϴ�.","Equip",0,200, 200,1,2),
            new EquipData("Weapon/Shield3", "�߱� ����","ü�� 300�� ������ŵ�ϴ�.","Equip",0,300, 300,2,3),
            new EquipData("Weapon/Shield4", "��� ����","ü�� 400�� ������ŵ�ϴ�.","Equip",0,400, 400,3,4)
        };
        skillDatas = new List<SkillData> {
            new SkillData("SkillIcon/Skill1", "�����ϼ�", " 20�Ÿ� ���� �ִ� ���� ���� ���İ��� �̵��Ͽ� ���� �޼Ҹ� ����.\n ��ٿ� 10��", "Skill",1000,10,10,"SkillIcon/SkillPrefab/EffectSkill1",1),
            new SkillData("SkillIcon/Skill2", "�����", " ����� ������ ���� ���߽�Ų��..\n ��ٿ� 10��", "Skill",1000,10,10,"SkillIcon/SkillPrefab/EffectSkill2",2),
            new SkillData("SkillIcon/Skill3", "������", " ���� �� ������ �������� �������� �߻��Ѵ�. ���� ������ �����ϸ� ū ������ �߻��Ѵ�.\n ��ٿ� 10��", "Skill",100,10,10,"SkillIcon/SkillPrefab/EffectSkill3",3),
            new SkillData("SkillIcon/Skill4", "ũ����", " ���� ���� ��� ���� �����Ѵ�.\n ��ٿ� 10��", "Skill",100,10,10,"SkillIcon/SkillPrefab/EffectSkill4",4),
            new SkillData("SkillIcon/Skill5", "����", " �ϴÿ��� 10���� ������ ��������.\n ��ٿ� 10��", "Skill",1000,10,10,"",5),
            new SkillData("SkillIcon/Skill6", "�̸�Ż", " �̵��ӵ��� ũ�� ������Ų��.\n ��ٿ� 10��", "Skill",1000,10,10,"",6),
            new SkillData("SkillIcon/Skill7", "���", " ü���� ��� ȸ���Ѵ�.\n ��ٿ� 10��", "Skill",1000,10,10,"",7),

        };
    }
}
[System.Serializable]
public class GameItemData
{
    public string iconPath;
    public string name;
    public string description;
    public string type;
    public int coolDown;
    public int requiredLV;
}
[System.Serializable]
public class PortionData : GameItemData
{
    public int hpRecovery;
    public int mpRecovery;
    public int itemPrice;
    public PortionData(string iconPath, string itemName, string itemDescription, string type, int hpRecovery, int mpRecovery, int coolDown, int itemPrice, int requiredLV)
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
    public EquipData(string iconPath, string itemName, string itemDescription, string type, int addAttack, int addHp, int itemPrice, int itemNum, int requiredLV)
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
    private bool isUnlocked;
    private List<SkillData> preRequiredSkills;
    public SkillData(string iconPath, string itemName, string itemDescription, string type, int damage, int coolDown, int consumMP, string prefabPath, int requiredLV)
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
    public void AddPreRequiredSkill(SkillData skill)
    {
        preRequiredSkills.Add(skill);
    }
    public void UnLockSkill()
    {
        this.isUnlocked = true;
    }
}