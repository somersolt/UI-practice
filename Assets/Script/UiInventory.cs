using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    private readonly string[] sortingOPtions =
    {
        "커스텀",
        "이름 오름차순",
        "이름 내림차순",
        "가격 오름차순",
        "가격 내림차순",
    };

    private readonly string[] filteringOPtions =
{
        "전부",
        "무기",
        "장비",
        "소모품",
    };

    public UIItemSlot prefab;
    ItemTable itemTable;
    int maxSlot = 30;
    int countSlot = 0;
    private List<string> allItemKeys;

    private List<ItemData> itemDataList = new List<ItemData>();
    private List<ItemData> inventoryItemDataList = new List<ItemData>();

    private List<UIItemSlot> slots = new List<UIItemSlot>();

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;
    public Button itemPush;
    public Button itemPop;

    public UISelect uISelect;


    private void UpdateItemSlots()
    {

        for(int i = 0; i < slots.Count; ++i)
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

    }


    private void Awake()
    {
        itemTable = DataTableManager.Get<ItemTable>(DataTableIds.Item);
        uISelect = FindAnyObjectByType<UISelect>();
        allItemKeys = itemTable.AllItemIds;

        for (int i = 0; i < maxSlot; i++)
        {
            var slot = Instantiate(prefab, gameObject.transform);
            slot.SetEmpty();
            slot.slotIndex = i;
            slots.Add(slot);
        }

        sorting.options.Clear();
        foreach (var option in sortingOPtions)
        {
            sorting.options.Add(new TMP_Dropdown.OptionData(option));
        }
        sorting.value = 0;
        sorting.RefreshShownValue();

        filtering.options.Clear();
        foreach (var option in filteringOPtions)
        {
            filtering.options.Add(new TMP_Dropdown.OptionData(option));
        }
        filtering.value = 0;
        filtering.RefreshShownValue();
    }

    private void Update()
    {
        if (uISelect.Onselected)
        {
            itemPop.interactable = true;
        }
        else
        {
            itemPop.interactable = false;   
        }
    }
    public void OnValueChangeShorting(int value)
    {
        Debug.Log("sortingOptions[value]");
    }

    public void OnValueChangeFiltering(int value)
    {
        Debug.Log("filteringOptions[value]");
    }

    public void OnClickItemAdd()
    {
        if(countSlot < slots.Count)
        {
            var randomItemId = allItemKeys[Random.Range(0, allItemKeys.Count)];
            itemDataList.Add(itemTable.Get(randomItemId));
            UpdateItemSlots();
        }
    }
    public void OnClickItemDelete()
    {
        uISelect.selectSlot.SetEmpty();
        uISelect.Onselected = false;
        for (int i = uISelect.index; i < countSlot - 1; i++)
        {
            slots[i].SetData(slots[i + 1].data);
        }
        slots[countSlot-1].SetEmpty();
        slots[maxSlot-1].SetEmpty();
        uISelect.selectType.text = "Type : ";
        uISelect.selectValue.text = "Value : ";
        uISelect.selectCost.text = "Cost : ";
        countSlot--;
    }


}
