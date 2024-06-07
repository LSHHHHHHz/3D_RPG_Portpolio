using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlots : MonoBehaviour
{
    protected ISlotData iSlotData;
    protected InventoryType inventoryType;
    [SerializeField] protected RectTransform slotsTransform;
    [SerializeField] protected GameObject slotPrefab;
    protected List<GameObject> slotPrefabList = new List<GameObject>();

    protected virtual void Awake()
    {
        SetSlots(iSlotData);
        SetSlotInteractions(slotsTransform);
    }
    protected void SetSlots(ISlotData slotData)
    {
        for (int i = slotPrefabList.Count; i < slotData.slotDatas.Count; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsTransform);
            slotPrefabList.Add(slot);
        }
        for (int i = 0; i < slotPrefabList.Count; i++)
        {
            ItemSlotUI itemSlotUI = slotPrefabList[i].GetComponentInChildren<ItemSlotUI>();
            DragSlotUI[] dragSlotUI = itemSlotUI.GetComponentsInChildren<DragSlotUI>();
            if (itemSlotUI != null)
            {
                itemSlotUI.SetData(slotData.slotDatas[i], slotData, slotData.slotDatas[i].item.type,inventoryType);
            }
            if (dragSlotUI[0] != null)
            {
                dragSlotUI[0].SetData(slotData.slotDatas[i], slotData, itemSlotUI.currentItemType, inventoryType);
            }
        }
    }
    protected void SetSlotInteractions(RectTransform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            int index = i;
            Transform transform= parent.GetChild(i).transform;
            ItemSlotUI slotUI = transform.GetComponentInChildren<ItemSlotUI>();
            DragSlotUI dragSlotUi = slotUI.GetComponentInChildren<DragSlotUI>();
            if(slotUI != null)
            {
                Button slotButton = dragSlotUi.buttonIcon;
                if(slotButton != null)
                {
                    slotButton.onClick.AddListener(() =>
                    {
                        ClickQuickPortionSlotButton(slotUI, index);
                    });
                }
            }
        }
    }
    protected void ClickQuickPortionSlotButton(ItemSlotUI slot, int index)
    {
        Player.instance.ClickQuickSlot(iSlotData, slot, index);
    }
}
