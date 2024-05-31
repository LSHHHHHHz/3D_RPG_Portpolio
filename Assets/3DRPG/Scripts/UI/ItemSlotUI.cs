using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Text description;
    [SerializeField] Text price;
    [SerializeField] Text levelRequirement;
    [SerializeField] Sprite nullImage;
    [SerializeField] Text itemCountText;
    [SerializeField] Image coolDownImage;
    [SerializeField] Button button;
    public SlotData currentSlotData { get; private set; }

    //드래그앤드랍
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform slotRectTransform;

    public Action<SlotData> endDragSlot { get; set; } = null;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetData(SlotData slotData)
    {
        this.currentSlotData = slotData;
        UpdateSlotUI();
    }
    void UpdateSlotUI()
    {
        if (itemIcon != null)
        {
            itemIcon.sprite = Resources.Load<Sprite>(currentSlotData.item.iconPath);
        }
        if (description != null)
        {
            description.text = currentSlotData.item.description;
        }
        if (price != null )
        {
            if(currentSlotData.item is PortionData portionData)
            {
                price.text = portionData.itemPrice.ToString();
            }
            if (currentSlotData.item is EquipData equipData)
            {
                price.text = equipData.itemPrice.ToString();
            }
        }
        if (levelRequirement != null)
        {
            levelRequirement.text = "필요 레벨" + " LV" + currentSlotData.item.requiredLV.ToString();
        }
        if (itemCountText != null)
        {
            if(currentSlotData.count>0)
            {
                itemCountText.text = currentSlotData.count.ToString();
            }
            else
            {
                itemCountText.gameObject.SetActive(false);
            }
        }
        if(coolDownImage != null)
        {

        }
    }
    public void OnDrop(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    }
}
