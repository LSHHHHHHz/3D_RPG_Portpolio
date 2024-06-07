using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopupUI : MonoBehaviour,IPopup
{
    InventoryType inventoryType;
    ISlotData shopData;
    GameItemData[] gameItemDatas;
    BuyPopup buyPopup;
    [SerializeField] string shopName;
    [SerializeField] GameObject buyPopupPrefab;
    [SerializeField] RectTransform slotsTransform;
    [SerializeField] GameObject slotPrefab;
    List<GameObject> slotPrefabList = new List<GameObject>();
    private void Start()
    {
        SetShopData(shopName);
        SetShopSlots();
        SetChildISlots(slotsTransform);
    }
    void SetShopData(string name)
    {
        switch (name)
        {
            case "포션":
                shopData = GameData.instance.portionShopData;
                gameItemDatas = GameData.instance.staticGameItemData.portionDatas.ToArray();
                inventoryType = InventoryType.PortionShop;
                break;
            case "장비":
                shopData = GameData.instance.equipShopData;
                gameItemDatas = GameData.instance.staticGameItemData.equipDatas.ToArray();
                inventoryType = InventoryType.EquipShop;
                break;
        }
    }
    void SetShopSlots()
    {
        for (int i = slotPrefabList.Count; i < shopData.slotDatas.Count; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotsTransform);
            slotPrefabList.Add(slotObj);
        }
        for(int i =0; i< shopData.slotDatas.Count; i++)
        {
            shopData.slotDatas[i].AddItem(gameItemDatas[i], 1);
            ItemSlotUI slotUI = slotPrefabList[i].GetComponentInChildren<ItemSlotUI>();
            if (slotUI != null)
            {
                slotUI.SetData(shopData.slotDatas[i], shopData, shopData.slotDatas[i].item.type, inventoryType);
            }
        }
    }
    private void SetChildISlots(RectTransform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform transform = parent.GetChild(i);
            ItemSlotUI slot = transform.GetComponentInChildren<ItemSlotUI>();
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
        if(buyPopup == null)
        {
            buyPopup = Instantiate(buyPopupPrefab, TransformFactory.instance.buyPopupTransform).GetComponent<BuyPopup>();
            buyPopup.SetData(slotData);
        }
        else
        {
            buyPopup.SetData(slotData);
            buyPopup.OpenPopupUI();
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
