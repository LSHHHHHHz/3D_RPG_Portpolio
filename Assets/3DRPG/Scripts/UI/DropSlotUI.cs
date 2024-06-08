using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType
{
    Shield,
    Weapon,
    Portion,
    Skill
}
public enum InventoryType
{
    ItemInventory,
    EquipItemInventory,
    QuickPortionSlot,
    PortionShop,
    EquipShop,
    SkillInventory,
    QuickSkillSlot
}

public class DropSlotUI : MonoBehaviour, IDropHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Text description;
    [SerializeField] Text price;
    [SerializeField] Text levelRequirement;
    [SerializeField] Sprite nullImage;
    [SerializeField] Text itemCountText;
    [SerializeField] Image coolDownImage;

    [SerializeField] GameObject infoPopupPrefab;
    public ItemType currentItemType { get; private set; }
    public InventoryType currentInventoryType { get; private set; }
    public bool isActiveCoolTime { get; private set; }
    public SlotData currentSlotData { get; private set; }
    public ISlotData currentISlot { get; private set; }

    InfoPopup infoPopup;
    private void Start()
    {
        currentSlotData.OnSlotDataChanged += SetData;
        currentSlotData.OnDataChanged += UpdateSlotUI;
    }
    public void SetData(SlotData data)
    {
        this.currentSlotData = data;
        this.currentItemType = data.itemType;
    }
    public void SetData(SlotData slotData, ISlotData islotData, ItemType itemType, InventoryType inventoryType)
    {
        this.currentSlotData = slotData;
        this.currentISlot = islotData;
        this.currentItemType = itemType;
        this.currentInventoryType = inventoryType;
        UpdateSlotUI();
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
        DragSlotUI dragSlotUI = eventData.pointerDrag.GetComponent<DragSlotUI>();
        if (CheckPossibleDrop(currentInventoryType, dragSlotUI.dragItemType))
        {
            ScrollRect scroll = eventData.pointerDrag.GetComponent<ScrollRect>();
            if (scroll != null)
            {
                return;
            }
            if (dragSlotUI.dragItemType != ItemType.Skill)
            {
                if (currentSlotData.item.name != dragSlotUI.dragSlotData.item.name)
                {
                    currentSlotData.TempItem(currentSlotData, dragSlotUI.dragSlotData);
                }
                else
                {
                    currentSlotData.MergeItem(currentSlotData, dragSlotUI.dragSlotData);
                }
            }
            else
            {
                currentSlotData.EquipSkill(currentSlotData, dragSlotUI.dragSlotData, currentISlot);
            }
        }
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
        if (infoPopupPrefab != null && currentSlotData.item != null && currentSlotData.item.name != "" && currentSlotData.item.name != null)
        {
            if (infoPopup == null)
            {
                infoPopup = Instantiate(infoPopupPrefab, TransformFactory.instance.infoPopupTransform).GetComponent<InfoPopup>();
                infoPopup.SetData(currentSlotData, this.transform);
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
    bool CheckPossibleDrop(InventoryType dropInventoryType, ItemType dragitemType)
    {
        switch (dropInventoryType)
        {
            case InventoryType.ItemInventory:
                return dragitemType != ItemType.Skill;
            case InventoryType.EquipItemInventory:
                return dragitemType == ItemType.Weapon || dragitemType == ItemType.Shield;
            case InventoryType.QuickPortionSlot:
                return dragitemType == ItemType.Portion;
            case InventoryType.SkillInventory:
                return false;
            case InventoryType.QuickSkillSlot:
                return dragitemType == ItemType.Skill;
            default:
                return false;
        }
    }
}
