using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SlotData
{
    [SerializeField] public GameItemData item;
    [SerializeField] public int count;
    [SerializeField] public int maxCount = 99;
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
    public void UseItem(SlotData slot)
    {
        if(slot.item == null || slot.count<=0) 
        {
            return;
        }
        slot.count--;
        OnDataChanged?.Invoke();
    }
    public void RemoveItem()
    {
        item = new GameItemData();
        count = 0;
        OnDataChanged?.Invoke();
    }
    public void TempItem(SlotData dropData, SlotData dragData)
    {
        GameItemData tempItem = dragData.item;
        int tempCount = dragData.count;

        dragData.item = dropData.item;
        dragData.count = dropData.count;

        dropData.item = tempItem;
        dropData.count = tempCount;

        OnDataChanged?.Invoke();
       // dropData.OnDataChanged?.Invoke();
       // dragData.OnDataChanged?.Invoke();
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
    [SerializeField] private List<SlotData> _slotDatas;
    public List<SlotData> slotDatas
    {
        get
        {
            return _slotDatas; 
        }
        private set
        {
            _slotDatas = value;
        }
    }

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
        InitializeSlots(3);
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
        InitializeSlots(7);
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
    public PortionShopData()
    {
        InitializeSlots(8);
    }
}
