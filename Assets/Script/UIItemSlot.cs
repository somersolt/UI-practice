using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class UIItemSlot : MonoBehaviour
{
    public int slotIndex {  get; set; }

    public Button button;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public ItemData data;
    public UISelect uISelect;

    private void Awake()
    {
        button = GetComponent<Button>();
        uISelect = FindAnyObjectByType<UISelect>();
    }
    public void SetEmpty()
    {
        this.data = null;

        itemIcon.sprite = null;
        itemName.text = string.Empty;
        button.interactable = false;

    }
    public void SetData(ItemData data)
    {
        this.data = data;

        itemIcon.sprite = data.GetSprite;
        itemName.text = data.GetName;
        button.interactable = true;
    }


    public void OnClick()
    {
        if (data.Id == null)
        {
            Debug.Log("Empty");
        }

        uISelect.selectSlot.SetData(data);
        uISelect.Onselected = true;
        uISelect.index = slotIndex;
        uISelect.selectType.text = " ";
        uISelect.OnSelect();
    }
}
