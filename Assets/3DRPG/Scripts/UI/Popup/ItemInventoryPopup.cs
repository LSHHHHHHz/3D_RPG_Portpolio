using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryPopup : MonoBehaviour,IPopup
{
    ItemInventoryData inventoryData;
    [SerializeField] RectTransform slotsTransform;
    [SerializeField] GameObject slotPrefab;
    List<GameObject> slotPrefabList = new List<GameObject>();

    private void Start()
    {
        inventoryData = UserDataViewer.instance.data.inventoryData;
        RefreshData();
        SetChildItemSlots(slotsTransform);
    }
    private void RefreshData()
    {
        RefreshSlots();
    }
    void RefreshSlots()
    {
        for(int i = slotPrefabList.Count; i<inventoryData.slotDatas.Count; i++ )
        {
            GameObject slotObject = Instantiate(slotPrefab,slotsTransform);
            slotPrefabList.Add(slotObject);
        }
        for(int i =0; i< inventoryData.slotDatas.Count; i++ )
        {
            ItemSlotUI slotUI = slotPrefabList[i].GetComponent<ItemSlotUI>();
            if(slotUI != null)
            {
                slotUI.SetData(inventoryData.slotDatas[i]);
            }
        }
    }
    void SetChildItemSlots(RectTransform slotsTransform)
    {
        for (int i = 0; i < slotsTransform.childCount; i++)
        {
            Transform transform = slotsTransform.GetChild(i);
            ItemSlotUI itemSlotUI = transform.GetComponent<ItemSlotUI>();
            if (itemSlotUI != null)
            {
                int slotIndex = i;


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
        for (int i = 0; i < inventoryData.slotDatas.Count; i++)
        {
            if (i == num)
            {
                inventoryData.slotDatas[i] = slot;
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
