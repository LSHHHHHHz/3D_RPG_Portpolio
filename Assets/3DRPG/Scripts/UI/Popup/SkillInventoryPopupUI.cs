using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventoryPopupUI : MonoBehaviour,IPopup
{
    GameItemData[] gameItemDatas;
    [SerializeField] InventoryType skillInventoryType;
    ISlotData skillInventoryData;
    [SerializeField] RectTransform slotsTransform;
    private List<GameObject> slotPrefabList = new List<GameObject>();
    private void Awake()
    {
        gameItemDatas = GameData.instance.staticGameItemData.skillDatas.ToArray();
        skillInventoryData = GameData.instance.skillInventoryData;
        skillInventoryType = InventoryType.SkillInventory;
        CheckTransformChild(slotsTransform);
        SetSlots();
    }
    void SetSlots()
    {
        for (int i = 0; i < skillInventoryData.slotDatas.Count; i++)
        {
            DropSlotUI slotUI = slotPrefabList[i].GetComponentInChildren<DropSlotUI>();
            DragSlotUI[] dragSlotUi = slotUI.GetComponentsInChildren<DragSlotUI>();
            skillInventoryData.slotDatas[i].AddItem(gameItemDatas[i], 1);
            if (slotUI != null)
            {
                slotUI.SetData(skillInventoryData.slotDatas[i], skillInventoryData, skillInventoryData.slotDatas[i].item.type, skillInventoryType);
            }
            if (dragSlotUi != null)
            {
                dragSlotUi[0].SetData(skillInventoryData.slotDatas[i], skillInventoryData, skillInventoryData.slotDatas[i].item.type, skillInventoryType);
            }
        }
    }
    void CheckTransformChild(RectTransform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
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
