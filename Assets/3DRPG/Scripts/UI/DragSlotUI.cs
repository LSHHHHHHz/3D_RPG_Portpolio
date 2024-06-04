using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlotUI : MonoBehaviour,  IBeginDragHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Sprite nullImage;
    [SerializeField] Text itemCountText;
    public SlotData currentSlotData { get; private set; }
    public ISlotData currentISlot { get; private set; }

    //드래그앤드랍
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform slotRectTransform;
    public Action<SlotData> endDragSlot { get; set; } = null;
    public Action<SlotData> dropSlot { get; set; } = null;
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void SetData(SlotData slotData, ISlotData islotData)
    {
        this.currentSlotData = slotData;
        this.currentISlot = islotData;
        UpdateSlotUI();
        currentSlotData.OnDataChanged += UpdateSlotUI;
    }
    void UpdateSlotUI()
    {
        if (itemIcon != null)
        {
            if (currentSlotData.item != null && currentSlotData.item.name != null)
            {
                itemIcon.sprite = Resources.Load<Sprite>(currentSlotData.item.iconPath);
            }
            if (currentSlotData.item == null || currentSlotData.item.name == "" || currentSlotData.count == 0)
            {
                itemIcon.sprite = nullImage;
            }
        }
        if (itemCountText != null)
        {
            if (currentSlotData.count > 0)
            {
                itemCountText.text = currentSlotData.count.ToString();
                itemCountText.gameObject.SetActive(true);
            }
            else
            {
                itemCountText.gameObject.SetActive(false);
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentISlot is PortionShopData || currentISlot is EquipShopData)
        {
            return;
        }

        dragSlotData = currentSlotData;
        dragISlotData = currentISlot;

        previousParent = transform.parent;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
            if (!RectTransformUtility.RectangleContainsScreenPoint(slotRectTransform, eventData.position, null))
            {

            }
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
