using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISelect : MonoBehaviour
{
    public UIItemSlot selectSlot;
    public TextMeshProUGUI selectType;
    public TextMeshProUGUI selectValue;
    public TextMeshProUGUI selectCost;
    public int index;
    public bool Onselected;
    public void OnSelect()
    {
        selectType.text = selectSlot.data.Type;
        selectValue.text = "Value : " + selectSlot.data.Value.ToString();
        selectCost.text = "Cost : " + selectSlot.data.Cost.ToString();
    }
}
