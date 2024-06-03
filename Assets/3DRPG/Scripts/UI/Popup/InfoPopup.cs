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
    public void SetData(SlotData slotData, Transform transform)
    {
        selectSlotData = slotData;
        dataImage.sprite = Resources.Load<Sprite>(selectSlotData.item.iconPath);
        dataNameText.text = selectSlotData.item.name;
        requiredLVText.text = selectSlotData.item.requiredLV.ToString();
        descriptionText.text = selectSlotData.item.description.ToString();
        this.transform.position = transform.position - new Vector3(-160,0,0);
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
