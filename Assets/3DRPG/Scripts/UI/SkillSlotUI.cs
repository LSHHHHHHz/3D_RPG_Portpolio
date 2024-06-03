using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Text description;
    [SerializeField] Text levelRequirement;
    [SerializeField] Sprite nullImage;
    [SerializeField] Image coolDownImage;
    public SlotData currentSlotData { get; private set; }

    //�巡�׾ص��
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform slotRectTransform;
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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
        if (levelRequirement != null)
        {
            levelRequirement.text = "�ʿ� ����" + " LV" + currentSlotData.item.requiredLV.ToString();
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
