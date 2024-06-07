using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Sprite nullImage;
    [SerializeField] public Button buttonIcon;

    public ItemType dragItemType;
    public InventoryType dragInventoryType;
    [SerializeField] public SlotData dragSlotData { get; private set; }
    public ISlotData dragISlotData { get; private set; }

    //드래그앤드랍
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;

    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform slotRectTransform;
    public Action initializeSlot { get; private set; } = null;
    public Action<SlotData> endDragSlot { get; set; } = null;
    public Action<SlotData> dropSlot { get; set; } = null;
    public bool isDragging { get; private set; } = false;
    private void Awake()
    {
        GameObject canvasObj = GameObject.Find("MainCanvas");
        if (canvasObj != null)
        {
            canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>().transform;
        }
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        dragSlotData.OnSlotDataChanged += SetData;
    }
    public void SetData(SlotData data)
    {
        this.dragSlotData = data;
        this.dragItemType = data.itemType;
    }
    public void SetData(SlotData slotData, ISlotData islotData, ItemType itemType, InventoryType inventoryType)
    {
        this.dragSlotData = slotData;
        this.dragISlotData = islotData;
        this.dragItemType = itemType;
        this.dragInventoryType= inventoryType;
        UpdateSlotUI();
        dragSlotData.OnDataChanged += UpdateSlotUI;
    }
    public void UpdateSlotUI()
    {
        if (itemIcon != null)
        {
            if (dragSlotData.item != null && dragSlotData.item.name != null)
            {
                itemIcon.sprite = Resources.Load<Sprite>(dragSlotData.item.iconPath);
            }
            if (dragSlotData.item == null || dragSlotData.item.name == "" || dragSlotData.count == 0)
            {
                itemIcon.sprite = nullImage;
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragSlotData == null || itemIcon.sprite == nullImage)
        {
            isDragging = false;
            return;
        }
        isDragging = true;
        previousParent = transform.parent;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }
        rect.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return; 
        }

        isDragging = false;
        transform.SetParent(previousParent);
        rect.position = previousParent.GetComponent<RectTransform>().position;
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
