using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickMenuUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryUIPrefab;
    [SerializeField] Transform inventoryTransform;
    private ItemInventoryPopupUI itemInventoryPopupUI;
    [SerializeField] GameObject euipInventoryUIPrefab;
    [SerializeField] Transform euipInventoryTransform;
    private EquipInventoryPopupUI equipInventoryPopupUI;
    [SerializeField] GameObject skillInventoryUIPrefab;
    [SerializeField] Transform skillInventoryTransform;
    private SkillInventoryPopupUI skillInventoryPopupUI;
    public void OpenInventoryUI()
    {

    }
    public void OpenEquipInventoryUI()
    {

    }
    public void OpenSkillInventoryUI()
    {

    }
}
