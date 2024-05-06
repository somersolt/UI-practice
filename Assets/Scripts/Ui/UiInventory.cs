using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Linq;
using UnityEditor.UIElements;
using Unity.VisualScripting;

public class UiInventory : MonoBehaviour
{
    private readonly string[] sortinOptions =
    {
        "커스텀",
        "이름 오름차순",
        "이름 내릭차순",
        "가격 오름차순",
        "가격 내림차순",
    };

    private readonly System.Comparison<SaveItemData>[] comparison =
    {
        (x, y) => x.customOrder.CompareTo(y.customOrder),
        (x, y) => x.data.GetName.CompareTo(y.data.GetName),
        (x, y) => y.data.GetName.CompareTo(x.data.GetName),
        (x, y) => x.data.Cost.CompareTo(y.data.Cost),
        (x, y) => y.data.Cost.CompareTo(x.data.Cost),
    };

    private readonly string[] filteringOptions =
    {
        "전부",
        "무기",
        "장비",
        "소모품",
    };
    private readonly System.Func<SaveItemData, bool>[] filter =
    {
        x => true,
        x => x.data.Type == "Weapon",
        x => x.data.Type == "Equip",
        x => x.data.Type == "Consumable",
    };

    private int sortinOption;
    private int filteringOption;

    public int maxSlot = 30;

    public GameObject CharacterPannel;
    public GameObject InventoryPannel;
    public UICharSelect uICharSelect;

    public UiItemSlot prefabSlot;

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public ScrollRect scrollRect;

    public Button buttonItemAdd;
    public Button buttonItemRemove;

    private ItemTable itemTable;
    private List<string> allItemKeys;

    private List<SaveItemData> itemDataList = new List<SaveItemData>();    // 원본
    private List<SaveItemData> inventoryItemDataList = new List<SaveItemData>();    // 정렬 + 필러링

    private List<UiItemSlot> slots = new List<UiItemSlot>();

    private UiItemSlot seletecUiItemSlot;

    private void UpdateItemSlots()
    {
        // 필터링 + 정렬 
        inventoryItemDataList = itemDataList.Where(filter[filteringOption]).ToList();
        inventoryItemDataList.Sort(comparison[sortinOption]);

        for (int i = 0; i < slots.Count; ++i)
        {
            if (i < inventoryItemDataList.Count)
            {
                slots[i].SetData(inventoryItemDataList[i]);
            }
            else
            {
                slots[i].SetEmpty();
            }
        }
        buttonItemAdd.interactable = itemDataList.Count < maxSlot; //버튼 클릭가능 여부 검사
    }

    private void Awake()
    {
        itemTable = DataTableMgr.Get<ItemTable>(DataTableIds.Item);
        allItemKeys = itemTable.AllItemIds;

        for (int i = 0; i < maxSlot; i++)
        {
            var slot = Instantiate(prefabSlot, scrollRect.content);
            slot.SetEmpty();
            slot.slotIndex = i;
            slot.button.onClick.AddListener(() =>
            {
                seletecUiItemSlot = slot;
                buttonItemRemove.interactable = true;
                var window = GetComponentInParent<UiWindowInventory>();
                if (window != null)
                {
                    window.itemInfo.SetData(seletecUiItemSlot.saveItemData);
                }
            });
            slots.Add(slot);
        }

        sorting.options.Clear();
        foreach (var option in sortinOptions)
        {
            sorting.options.Add(new TMP_Dropdown.OptionData(option));
        }
        sorting.value = 0;
        sorting.RefreshShownValue();
        sortinOption = sorting.value;

        filtering.options.Clear();
        foreach (var option in filteringOptions)
        {
            filtering.options.Add(new TMP_Dropdown.OptionData(option));
        }
        filtering.value = 0;
        filtering.RefreshShownValue();
        filteringOption = filtering.value;
    }

    private void OnEnable()
    {
        //SaveLoadSystem.Load();
        itemDataList = SaveLoadSystem.CurrSaveData.saveItems.ToList();
        sorting.value = SaveLoadSystem.CurrSaveData.itemInvenSorting;
        filtering.value = SaveLoadSystem.CurrSaveData.itemFilteringSorting;

        UpdateItemSlots();

        buttonItemAdd.interactable = itemDataList.Count < maxSlot;

        buttonItemRemove.interactable = false;
        seletecUiItemSlot = null;

    }
    private void OnDisable()
    {
        SaveLoadSystem.CurrSaveData.itemInvenSorting = sorting.value;
        SaveLoadSystem.CurrSaveData.itemFilteringSorting = filtering.value;
        SaveLoadSystem.CurrSaveData.saveItems = itemDataList.ToList();
        SaveLoadSystem.Save();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SaveLoadSystem.CurrSaveData.saveItems = itemDataList.ToList();
            SaveLoadSystem.Save();

        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {

        }
    }

    public void OnValueChangeSoring(int value)
    {
        sortinOption = value;
        UpdateItemSlots();
    }

    public void OnValueChangeFiltering(int value)
    {
        filteringOption = value;
        UpdateItemSlots();
    }

    public void OnClickItemAdd()
    {
        if (itemDataList.Count < slots.Count)
        {
            var randomItemId = allItemKeys[Random.Range(0, allItemKeys.Count)];
            var item = new SaveItemData();
            item.data = itemTable.Get(randomItemId);
            item.creationTime = System.DateTime.Now;
            item.instanceId = Animator.StringToHash(item.creationTime.Ticks.ToString());
            item.customOrder = itemDataList.Count;
            itemDataList.Add(item);
            UpdateItemSlots();
        }
        //buttonItemAdd.interactable = itemDataList.Count < maxSlot;


    }

    public void OnClickItemReomve()
    {
        itemDataList.RemoveAll(x => x.instanceId == seletecUiItemSlot.saveItemData.instanceId);
        UpdateItemSlots();

        seletecUiItemSlot = null;
        var window = GetComponentInParent<UiWindowInventory>();
        if (window != null)
        {
            window.itemInfo.SetEmpty();
        }

        //buttonItemAdd.interactable = itemDataList.Count < maxSlot;
        buttonItemRemove.interactable = false;
    }

    public void onClickEquipItem()
    {
        if (seletecUiItemSlot == null)
        {
            return;
        }
        CharacterPannel.SetActive(true);
        InventoryPannel.SetActive(false);
        switch (uICharSelect.buttonCount)
        {
            case 1:
                uICharSelect.charDataList[uICharSelect.currentSlotIndex].equip1 = seletecUiItemSlot.saveItemData.data;
                break;
            case 2:
                uICharSelect.charDataList[uICharSelect.currentSlotIndex].equip2 = seletecUiItemSlot.saveItemData.data;
                break;
            case 3:
                uICharSelect.charDataList[uICharSelect.currentSlotIndex].equip3 = seletecUiItemSlot.saveItemData.data;
                break;
        }
        uICharSelect.EquipSlotUpdate();
    }

}
