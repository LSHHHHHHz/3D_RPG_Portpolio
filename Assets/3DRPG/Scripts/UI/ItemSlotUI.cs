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

    [SerializeField] GameObject infoPopupPrefab;
    public bool isActiveCoolTime { get; private set; }
    public SlotData currentSlotData { get; private set; }
    public ISlotData currentISlot { get; private set; }

    //드래그앤드랍
    Transform canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform slotRectTransform;

    static SlotData dragSlotData;
    static ISlotData dragISlotData;
    InfoPopup infoPopup;
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
        if (description != null)
        {
            description.text = currentSlotData.item.description;
        }
        if (price != null)
        {
            if (currentSlotData.item is PortionData portionData)
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
    public void CoolDown(int coolTime)
    {
        if (coolDownImage != null)
        {
            coolDownImage.gameObject.SetActive(true);
            StartCoroutine(CoolDownCoroutine(coolTime));
        }
    }
    IEnumerator CoolDownCoroutine(int coolTime)
    {
        float elapsedTime = 0;
        isActiveCoolTime = true;
        while (elapsedTime < coolTime)
        {
            elapsedTime += Time.deltaTime;
            coolDownImage.fillAmount = 1 - (elapsedTime / coolTime);
            yield return null;
        }
        coolDownImage.fillAmount = 0;
        coolDownImage.gameObject.SetActive(false);
        isActiveCoolTime = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (currentSlotData.item.name == dragSlotData.item.name)
        {
            currentSlotData.AddItem(currentSlotData.item, dragSlotData.count);
            dragSlotData.RemoveItem();
        }
        else
        {
            currentSlotData.TempItem(currentSlotData, dragSlotData);
        }
        dragSlotData = null;
        currentISlot = null;
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
    public void OnPointerExit(PointerEventData eventData)
    {
        if (infoPopup != null)
        {
            infoPopup.ClosePopupUI();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (infoPopupPrefab != null &&currentSlotData.item != null && currentSlotData.item.name != "" && currentSlotData.item.name != null)
        {
            if (infoPopup == null)
            {
                infoPopup = Instantiate(infoPopupPrefab, TransformFactory.instance.infoPopupTransform).GetComponent<InfoPopup>();
                infoPopup.SetData(currentSlotData,this.transform);
            }
            else
            {
                infoPopup.OpenPopupUI();
                infoPopup.SetData(currentSlotData, this.transform);
            }
        }
        else
        {
            return;
        }
    }
}
