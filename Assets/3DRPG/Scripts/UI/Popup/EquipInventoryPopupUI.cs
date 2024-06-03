using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInventoryPopupUI : MonoBehaviour,IPopup
{
    ISlotData equipInventorSlotData;
    GameItemData[] gameItemDatas;
    [SerializeField] RectTransform[] equipSlots;

    private void Awake()
    {
        equipInventorSlotData = GameData.instance.equipInventoryData;
    }
    void SetEquipSlot()
    {
        for(int i =0; i< equipSlots.Length; i++)
        {
            ItemSlotUI slotUI = equipSlots[i].GetComponent<ItemSlotUI>();
            slotUI.dropSlot += ChangeEquipSlot;
        }
    }
    void ChangeEquipSlot(SlotData data)
    {

    }
    public void ClosePopupUI()
    {
        throw new System.NotImplementedException();
    }

    public void OpenPopupUI()
    {
        throw new System.NotImplementedException();
    }
}
