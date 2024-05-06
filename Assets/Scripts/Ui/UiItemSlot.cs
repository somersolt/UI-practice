using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiItemSlot : MonoBehaviour
{
    public int slotIndex { get; set; }

    public Button button;

    public Image itemIcon;
    public TextMeshProUGUI itemName;

    public SaveItemData saveItemData {  get; set; }

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetEmpty()
    {
        button.interactable = false;

        saveItemData = null;

        itemIcon.sprite = null;
        itemName.text = string.Empty;
    }

    public void SetData(SaveItemData itemData)
    {
        saveItemData = itemData;

        itemIcon.sprite = saveItemData.data.GetSprite;
        itemName.text = saveItemData.data.GetName;
        button.interactable = true;
    }



    public void OnClick()
    {
        Debug.Log($"Slot Index: {slotIndex}");
        if (saveItemData == null)
        {
            Debug.Log("Empty");
            return;
        }
        Debug.Log($"Item Id: {saveItemData.data.Id}");
    }
}
