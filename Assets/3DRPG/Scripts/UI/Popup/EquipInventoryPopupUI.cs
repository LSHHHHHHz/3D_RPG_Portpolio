using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInventoryPopupUI : MonoBehaviour,IPopup
{
    [SerializeField] InventoryType inventoryType;
    ISlotData equipInventoryData;
    [SerializeField] RectTransform slotsTransform;
    private List<GameObject> slotPrefabList = new List<GameObject>();
    private void Awake()
    {
        equipInventoryData = GameData.instance.equipInventoryData;
        inventoryType = InventoryType.EquipItemInventory;
        CheckTransformChild(slotsTransform);
        SetSlots();
    }
    void SetSlots()
    {
        for (int i = 0; i < equipInventoryData.slotDatas.Count; i++)
        {
            DropSlotUI slotUI = slotPrefabList[i].GetComponentInChildren<DropSlotUI>();
            DragSlotUI[] dragSlotUi = slotUI.GetComponentsInChildren<DragSlotUI>();
            if (slotUI != null)
            {
                slotUI.SetData(equipInventoryData.slotDatas[i], equipInventoryData, equipInventoryData.slotDatas[i].item.type, inventoryType);
            }
            if (dragSlotUi != null)
            {
                dragSlotUi[0].SetData(equipInventoryData.slotDatas[i], equipInventoryData, equipInventoryData.slotDatas[i].item.type, inventoryType);
            }
        }
    }
    void CheckTransformChild(RectTransform parent)
    {
        for(int i =0; i<parent.childCount; i++)
        {
            slotPrefabList.Add(parent.GetChild(i).gameObject);
        }
    }
    public void ClosePopupUI()
    {
        gameObject.SetActive(false);
    }

    public void OpenPopupUI()
    {
        gameObject.SetActive(true);
    }
}
