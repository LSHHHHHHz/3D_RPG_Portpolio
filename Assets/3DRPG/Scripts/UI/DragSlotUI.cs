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
    public Button buttonIcon { get; private set; }
    public ItemType dragItemType { get; private set; }
    public InventoryType dragInventoryType { get; private set; }
    public SlotData dragSlotData;
    public ISlotData dragISlotData { get; private set; }

    //드래그앤드랍
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    Transform previousParent;
    RectTransform slotRectTransform;
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
        buttonIcon = GetComponent<Button>();
    }
    private void Start()
    {
        dragSlotData.OnSlotDataChanged += SetData;
        dragSlotData.OnDataChanged += UpdateSlotUI;
    }
    private void SetData(SlotData data)
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
    }
    public void UpdateSlotUI()
    {
        if (itemIcon != null)
        {
            if (dragSlotData.item != null && dragSlotData.item.name != null)
            {
                itemIcon.sprite = Resources.Load<Sprite>(dragSlotData.item.iconPath);
            }
            if (dragSlotData.item == null || dragSlotData.item.name == "" || (dragSlotData.item.type != ItemType.Skill && dragSlotData.count == 0))
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
