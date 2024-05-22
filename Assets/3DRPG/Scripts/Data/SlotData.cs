using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SlotData
{
    public GameItemData item;
    public int count;
    public int maxCount = 99;

    public void AddItem(GameItemData newItem, int newCount)
    {
        if (newItem == null || newCount <= 0)
            return;

        if (item == null || item != newItem)
        {
            item = newItem;
            count = newCount;
        }
        else
        {
            count += newCount;
            if (count > maxCount)
            {
                count = maxCount;
            }
        }
    }

    public void RemoveItem()
    {
        item = null;
        count = 0;
    }

    public GameItemData GetItem()
    {
        return item;
    }
}

public interface ISlotData
{
    void InitializeSlots(int count);
}

[Serializable]
public class SlotDataInitialize : ISlotData
{
    public List<SlotData> slotDatas;

    public void InitializeSlots(int count)
    {
        slotDatas = new List<SlotData>(count);
        for (int i = 0; i < count; i++)
        {
            slotDatas.Add(new SlotData());
        }
    }
}

[Serializable]
public class QuickPortionSlotData : SlotDataInitialize
{
    public QuickPortionSlotData()
    {
        InitializeSlots(2);
    }
}

[Serializable]
public class QuickSkillSlotData : SlotDataInitialize
{
    public QuickSkillSlotData()
    {
        InitializeSlots(5);
    }
}

[Serializable]
public class ItemInventoryData : SlotDataInitialize
{
    public ItemInventoryData()
    {
        InitializeSlots(28);
    }
}

[Serializable]
public class SkillInventoryData : SlotDataInitialize
{
    public SkillInventoryData()
    {
        InitializeSlots(8);
    }
}

[Serializable]
public class EquipmentData : SlotDataInitialize
{
    public EquipmentData()
    {
        InitializeSlots(2);
    }
}

[Serializable]
public class ShopData : ISlotData
{
    public List<SlotData> portionShopSlotDatas;
    public List<SlotData> equipShopSlotData;

    public void InitializeSlots(int count)
    {
        portionShopSlotDatas = new List<SlotData>(count);
        for (int i = 0; i < count; i++)
        {
            portionShopSlotDatas.Add(new SlotData());
        }

        equipShopSlotData = new List<SlotData>(count);
        for (int i = 0; i < count; i++)
        {
            equipShopSlotData.Add(new SlotData());
        }
    }

    public ShopData()
    {
        InitializeSlots(8);
    }

    public List<SlotData> GetSlotsByNumber(int shopNumber)
    {
        if (shopNumber == 1)
        {
            return portionShopSlotDatas;
        }
        else if (shopNumber == 2)
        {
            return equipShopSlotData;
        }
        else
        {
            return null;
        }
    }
}
