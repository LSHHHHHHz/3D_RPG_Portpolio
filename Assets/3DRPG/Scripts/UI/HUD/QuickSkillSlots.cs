using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSkillSlots : QuickSlotsBase
{
    protected override void Awake()
    {
        iSlotData = Player.instance.quickSkillSlotData;
        inventoryType = InventoryType.QuickSkillSlot;
        base.Awake();
    }
}
