using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour, IPopup
{
    SlotData selectSlotData;

    [SerializeField] Image dataImage;
    [SerializeField] Text dataNameText;
    [SerializeField] Text requiredLVText;
    [SerializeField] Text descriptionText;
    public void SetData(SlotData slotData)
    {
        selectSlotData = slotData;
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
