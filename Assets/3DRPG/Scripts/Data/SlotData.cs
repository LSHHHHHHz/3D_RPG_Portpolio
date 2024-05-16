using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

public interface ISlotDataContainer
{
    void InitializeSlots(int count);
}

[System.Serializable]
public class SlotDataContainer : ISlotDataContainer
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

[System.Serializable]
public class QuickPortionSlotData : SlotDataContainer
{
    public QuickPortionSlotData()
    {
        InitializeSlots(2);
    }
}

[System.Serializable]
public class QuickSkillSlotData : SlotDataContainer
{
    public QuickSkillSlotData()
    {
        InitializeSlots(5);
    }
}

[System.Serializable]
public class InventoryData : SlotDataContainer
{
    public InventoryData()
    {
        InitializeSlots(28);
    }
}

[System.Serializable]
public class SkillInventoryData : SlotDataContainer
{
    public SkillInventoryData()
    {
        InitializeSlots(8);
    }
}

[System.Serializable]
public class EquipmentData : SlotDataContainer
{
    public EquipmentData()
    {
        InitializeSlots(2);
    }
}

[System.Serializable]
public class ShopData : ISlotDataContainer
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
