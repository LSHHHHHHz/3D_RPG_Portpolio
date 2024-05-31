using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPopup : MonoBehaviour,IPopup
{
    SlotData selectSlotData;
    int buyCount;
    int itemPrice;
    public void SetData(SlotData slotData)
    {
        selectSlotData= slotData;
    }
    public void BuyItem()
    {
        foreach(var data in GameData.instance.inventoryData.slotDatas)
        {
            if(data.count == 0)
            {
                data.AddItem(selectSlotData.item, 1);
                return;
            }
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
