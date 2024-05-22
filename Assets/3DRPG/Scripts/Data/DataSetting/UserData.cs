using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class UserData 
{
    public static UserData instance;

    public ItemInventoryData inventoryData;
    public EquipmentData equipmentData;
    public QuickPortionSlotData quickPortionSlotData;
    public QuickSkillSlotData quickSkillSlotData;
    public SkillInventoryData skillInventoryData;
}
