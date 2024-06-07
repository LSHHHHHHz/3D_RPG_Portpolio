using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickPortionSlots : MonoBehaviour
{
    ISlotData portionSlotData;
    InventoryType inventoryType;
    [SerializeField] private RectTransform slotsTransform;
    [SerializeField] private GameObject slotPrefab;
    private List<GameObject> slotPrefabList = new List<GameObject>();

    private void Awake()
    {
        portionSlotData = GameData.instance.quickPortionSlotData;
        inventoryType = InventoryType.QuickPortionSlot;
        SetSlots();
        SetSlotInteractions(slotsTransform);
    }
    private void SetSlots()
    {
        for (int i = slotPrefabList.Count; i < portionSlotData.slotDatas.Count; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsTransform);
            slotPrefabList.Add(slot);
        }
        for (int i = 0; i < slotPrefabList.Count; i++)
        {
            ItemSlotUI itemSlotUI = slotPrefabList[i].GetComponentInChildren<ItemSlotUI>();
            if (itemSlotUI != null)
            {
                itemSlotUI.SetData(portionSlotData.slotDatas[i], portionSlotData, portionSlotData.slotDatas[i].item.type,inventoryType);
            }
        }
    }
    private void SetSlotInteractions(RectTransform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            int index = i;
            Transform transform= parent.GetChild(i).transform;
            ItemSlotUI slotUI = transform.GetComponentInChildren<ItemSlotUI>();
            if(slotUI != null)
            {
                Button slotButton = slotUI.GetComponentInChildren<Button>();
                if(slotButton != null)
                {
                    slotButton.onClick.AddListener(() =>
                    {
                        ClickSlotButton(slotUI, index);
                    });
                }
            }
        }
    }
    private void ClickSlotButton(ItemSlotUI slot, int index)
    {
        if (portionSlotData is QuickPortionSlotData quickPortionSlotData && !slot.isActiveCoolTime)
        {
            if (quickPortionSlotData.slotDatas[index].count > 0)
            {
                slot.CoolDown(quickPortionSlotData.slotDatas[index].item.coolDown);
                quickPortionSlotData.slotDatas[index].UseItem(quickPortionSlotData.slotDatas[index]);
            }
        }
    }
}
