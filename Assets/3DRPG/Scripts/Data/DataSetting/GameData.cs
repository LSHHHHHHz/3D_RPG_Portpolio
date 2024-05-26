using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class GameData 
{
    public static GameData instance;

    public ItemInventoryData inventoryData;
    public EquipmentData equipmentData;
    public QuickPortionSlotData quickPortionSlotData;
    public QuickSkillSlotData quickSkillSlotData;
    public SkillInventoryData skillInventoryData;

    public CharacterData characterData;
}
