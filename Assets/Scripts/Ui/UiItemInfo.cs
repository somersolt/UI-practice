using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiItemInfo : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textType;
    public TextMeshProUGUI textVale;
    public TextMeshProUGUI textCost;
    public TextMeshProUGUI textDesc;

    private SaveItemData itemData;

    public void SetEmpty()
    {
        itemData = null;

        icon.sprite = null;
        textName.text = string.Empty;
        textType.text = string.Empty;
        textVale.text = string.Empty;
        textCost.text = string.Empty;
        textDesc.text = string.Empty;
    }

    public void SetData(SaveItemData data)
    {
        itemData = data;

        icon.sprite = data.data.GetSprite;
        textName.text = data.data.GetName;
        textType.text = data.data.Type;
        textVale.text = data.data.Value.ToString();
        textCost.text = data.data.Cost.ToString();
        textDesc.text = data.data.GetDesc;
    }
}
