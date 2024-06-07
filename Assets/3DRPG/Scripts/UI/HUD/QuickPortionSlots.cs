using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickPortionSlots : QuickSlots
{
    protected override void Awake()
    {
        iSlotData = Player.instance.quickPortionSlotData;
        inventoryType = InventoryType.QuickPortionSlot;
        base.Awake();
    }
}
