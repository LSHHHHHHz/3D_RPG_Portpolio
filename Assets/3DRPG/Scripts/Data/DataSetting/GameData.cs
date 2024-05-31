using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class GameData
{
    private static GameData _instance;
    public static GameData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    public ItemInventoryData inventoryData;
    public EquipmentInventoryData equipInventoryData;
    public QuickPortionSlotData quickPortionSlotData;
    public QuickSkillSlotData quickSkillSlotData;
    public SkillInventoryData skillInventoryData;
    public EquipShopData equipShopData;
    public PortionShopData portionShopData;

    public CharacterData characterData;
    public GameData()
    {
        inventoryData = new ItemInventoryData();
        equipInventoryData = new EquipmentInventoryData();
        quickPortionSlotData = new QuickPortionSlotData();
        quickSkillSlotData = new QuickSkillSlotData();
        skillInventoryData = new SkillInventoryData();
        characterData = new CharacterData();
        equipShopData = new EquipShopData();
        portionShopData = new PortionShopData();
    }
    [ContextMenu("Save To Json Data")]
    public void Save()
    {
        string jsonData = JsonUtility.ToJson(this, true);
        string path = Path.Combine(Application.dataPath, "UserData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("Load From Json Data")]
    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "UserData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(jsonData, instance);
        }
    }
}
