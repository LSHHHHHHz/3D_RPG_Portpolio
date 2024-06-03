using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventoryPopupUI : MonoBehaviour,IPopup
{
    ISlotData skillInventoryData;
    GameItemData[] gameItemDatas;
    [SerializeField] RectTransform[] skillSlots;
    private void Awake()
    {
        skillInventoryData = GameData.instance.skillInventoryData;
        SetSkillData();
        SetChildSkillSlot();
    }
    void SetSkillData()
    {
        gameItemDatas = StaticGameItemData.instance.skillDatas.ToArray();
    }
    void SetChildSkillSlot()
    {
        for(int i=0; i< skillSlots.Length; i++)
        {
            skillInventoryData.slotDatas[i].AddItem(gameItemDatas[i], 1);
            SkillSlotUI skillSlot = skillSlots[i].GetComponent<SkillSlotUI>();
            if(skillSlot != null)
            {
                skillSlot.SetData(skillInventoryData.slotDatas[i]);
            }
        }
    }
    public void ClosePopupUI()
    {
        throw new System.NotImplementedException();
    }

    public void OpenPopupUI()
    {
        throw new System.NotImplementedException();
    }
}
