using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPopup : MonoBehaviour, IPopup
{
    SlotData selectSlotData;
    int buyCount;
    [SerializeField] Text buyCountText;
    int itemPrice;
    [SerializeField] Text itemPriceText;
    [SerializeField] Image itemImage;
    public void SetData(SlotData slotData)
    {
        selectSlotData = slotData;
        buyCount = 1;
        buyCountText.text = buyCount.ToString();
        itemImage.sprite = Resources.Load<Sprite>(selectSlotData.item.iconPath);
        ToTalItemPrice();
    }
    public void BuyItem()
    {
        foreach (var data in GameData.instance.inventoryData.slotDatas)
        {
            if (data.count == 0)
            {
                data.AddItem(selectSlotData.item, buyCount);
                break;
            }
        }
        ClosePopupUI();
    }
    public void BuyCountUp()
    {
        buyCount++;
        if (buyCount > 99)
        {
            buyCount = 99;
            return;
        }
        buyCountText.text = buyCount.ToString();
        ToTalItemPrice();
    }
    public void BuyCountDown()
    {
        buyCount--;
        if (buyCount < 1)
        {
            buyCount = 1;
            return;
        }
        buyCountText.text = buyCount.ToString();
        ToTalItemPrice();
    }
    void ToTalItemPrice()
    {
        if (selectSlotData.item is PortionData portion)
        {
            itemPrice = buyCount * portion.itemPrice;
            itemPriceText.text =  itemPrice.ToString();
        }
        else if (selectSlotData.item is EquipData equip)
        {
            itemPrice = buyCount * equip.itemPrice;
            itemPriceText.text = itemPrice.ToString();
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
