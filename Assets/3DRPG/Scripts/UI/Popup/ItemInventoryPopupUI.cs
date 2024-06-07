using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryPopupUI : MonoBehaviour,IPopup
{
    [SerializeField]InventoryType InventoryType;
    ISlotData itemInventoryData;
    [SerializeField] RectTransform slotsTransform;
    [SerializeField] GameObject slotPrefab;
    List<GameObject> slotPrefabList = new List<GameObject>();

    private void Awake()
    {
        itemInventoryData = GameData.instance.inventoryData;
        SetSlots();
        SetSlotInteractions(slotsTransform);
    }
    void SetSlots()
    {
        for(int i = slotPrefabList.Count; i<itemInventoryData.slotDatas.Count; i++ )
        {
            GameObject slotObject = Instantiate(slotPrefab,slotsTransform);
            slotPrefabList.Add(slotObject);
        }
        for(int i =0; i< itemInventoryData.slotDatas.Count; i++ )
        {
            ItemSlotUI slotUI = slotPrefabList[i].GetComponentInChildren<ItemSlotUI>();
            DragSlotUI[] dragSlotUi = slotUI.GetComponentsInChildren<DragSlotUI>();
            if(slotUI != null)
            {
                slotUI.SetData(itemInventoryData.slotDatas[i], itemInventoryData, itemInventoryData.slotDatas[i].item.type, InventoryType);;
            }
            if(dragSlotUi != null)
            {
                dragSlotUi[0].SetData(itemInventoryData.slotDatas[i], itemInventoryData, slotUI.currentItemType,slotUI.currentInventoryType); 
            }
        }
    }
    void SetSlotInteractions(RectTransform slotsTransform)
    {
        for (int i = 0; i < slotsTransform.childCount; i++)
        {
            Transform transform = slotsTransform.GetChild(i);
            ItemSlotUI itemSlotUI = transform.GetComponentInChildren<ItemSlotUI>();
            if (itemSlotUI != null)
            {
                if (itemSlotUI.GetComponent<Button>() != null)
                {
                    Button slotButton = itemSlotUI.GetComponent<Button>();
                    slotButton.onClick.AddListener(() =>
                    {
                        Debug.Log("버튼이 있을 경우만");
                    });
                }
            }
        }
    }
    void SetSlotData(SlotData slot, int num)
    {
        for (int i = 0; i < itemInventoryData.slotDatas.Count; i++)
        {
            if (i == num)
            {
                itemInventoryData.slotDatas[i] = slot;
                break;
            }
        }
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
