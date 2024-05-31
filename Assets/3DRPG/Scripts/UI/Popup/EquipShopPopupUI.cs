using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipShopPopupUI : MonoBehaviour,IPopup
{
    ISlotData equipShopData;
    BuyPopup buyPopup;
    [SerializeField] GameObject buyPopupPrefab;
    [SerializeField] Transform buyPopupTransform;
    [SerializeField] RectTransform slotsTransform;
    [SerializeField] GameObject slotPrefab;
    List<GameObject> slotPrefabList = new List<GameObject>();
    private void Start()
    {
        equipShopData = GameData.instance.equipShopData;
        Refresh();
        SetChildISlots(slotsTransform);
    }
    void Refresh()
    {
        RefreshSlotsData();
    }
    void RefreshSlotsData()
    {
        for (int i = slotPrefabList.Count; i < equipShopData.slotDatas.Count; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotsTransform);
            slotPrefabList.Add(slotObj);
        }
        for(int i =0; i< equipShopData.slotDatas.Count; i++)
        {
            equipShopData.slotDatas[i].AddItem(StaticGameItemData.instance.equipDatas[i],1);
            ItemSlotUI slotUI = slotPrefabList[i].GetComponent<ItemSlotUI>();
            if (slotUI != null)
            {
                slotUI.SetData(equipShopData.slotDatas[i]);
            }
        }
    }
    private void SetChildISlots(RectTransform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform transform = parent.GetChild(i);
            ItemSlotUI slot = transform.GetComponent<ItemSlotUI>();
            if (slot != null)
            {
                int slotIndex = i;
                Button slotButton = slot.GetComponent<Button>();
                slotButton.onClick.AddListener(() =>
                {
                    ClickItemShopButton(slot.currentSlotData);
                });
            }
        }
    }
    void ClickItemShopButton(SlotData slotData)
    {
        //클릭했을 때 무슨데이턴지 확인하고 그 데이터를 잠시 보관해야함
        if(buyPopup == null)
        {
            buyPopup = Instantiate(buyPopupPrefab, buyPopupTransform).GetComponent<BuyPopup>();
            buyPopup.SetData(slotData);
        }
        else
        {
            buyPopup.SetData(slotData);
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
