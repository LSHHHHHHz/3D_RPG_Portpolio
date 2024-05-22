using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Sprite nullImage;
    [SerializeField] Text itemCountText;
    SlotData currentSlotData;


    public void SetData(SlotData slotData)
    {
        this.currentSlotData = slotData;
    }
    void UpdateSlotUI()
    {

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
