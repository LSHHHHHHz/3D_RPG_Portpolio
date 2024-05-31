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
    public event Action OnDataChanged;
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
        OnDataChanged?.Invoke();
    }

    public void RemoveItem()
    {
        item = null;
        count = 0;
        OnDataChanged?.Invoke();
    }

    public GameItemData GetItem()
    {
        return item;
    }
}

public interface ISlotData
{
    void InitializeSlots(int count);
    List<SlotData> slotDatas { get; }
}

[Serializable]
public class SlotDataInitialize : ISlotData
{
    public List<SlotData> slotDatas { get; private set;}

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
    public void AddSlot()
    {
        slotDatas.Add(new SlotData());
    }
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
public class EquipmentInventoryData : SlotDataInitialize
{
    public EquipmentInventoryData()
    {
        InitializeSlots(2);
    }
}
[Serializable]

public class EquipShopData : SlotDataInitialize
{
    public EquipShopData()
    {
        InitializeSlots(8);
    }
}
[Serializable]

public class PortionShopData : SlotDataInitialize
{
   public  PortionShopData()
    {
        InitializeSlots(8);
    }
}
