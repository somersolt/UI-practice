using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class UICharSelect : MonoBehaviour
{
    public List<SaveCharacterData> charDataList = new List<SaveCharacterData>();
    public UICharSlot uiCharSlot;
    public GameObject CharacterPannel;
    public GameObject InventoryPannel;

    public Button[] buttons = new Button[3];
    public Button currentButton;
    public int buttonCount;
    public int currentSlotIndex;
    private void Awake()
    {
        // uiCharSlot을 Awake() 메서드에서 초기화
        uiCharSlot = GetComponent<UICharSlot>();
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => InventoryOpen(buttonIndex));
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log(charDataList.Count.ToString());
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            SaveLoadSystem.CurrSaveData.saveCharacters = charDataList.ToList();
            SaveLoadSystem.Save();
        }
    }
    private void OnEnable()
    {
        //SaveLoadSystem.Load();
        charDataList.Clear();
        charDataList = SaveLoadSystem.CurrSaveData.saveCharacters.ToList();
        if (charDataList.Count < 4)
        {
            for (int i = 0; i < 4; i++)
            {
                var characterData = new SaveCharacterData();
                characterData.instanceId = i;
                charDataList.Add(characterData);
            }
        }
    }

    private void OnDisable()
    {
        SaveLoadSystem.CurrSaveData.saveCharacters = charDataList.ToList();
        SaveLoadSystem.Save();
    }

    public void SetKnight()
    {
        if (charDataList[0].isEmpty)
        {
            var newData = new SaveCharacterData();
            newData.isEmpty = false;
            newData.data = DataTableMgr.Get<CharacterTable>(DataTableIds.character).Get("Char1");
            charDataList[0] = newData;
        }
        uiCharSlot.SetData(charDataList[0]);
        currentSlotIndex = 0;
        EquipSlotUpdate();

    }

    public void SetArcher()
    {
        if (charDataList[1].isEmpty)
        {
            var newData = new SaveCharacterData();
            newData.isEmpty = false;
            newData.data = DataTableMgr.Get<CharacterTable>(DataTableIds.character).Get("Char2");
            charDataList[1] = newData;
        }
        uiCharSlot.SetData(charDataList[1]);
        currentSlotIndex = 1;
        EquipSlotUpdate();

    }

    public void SetWitch()
    {
        if (charDataList[2].isEmpty)
        {
            var newData = new SaveCharacterData();
            newData.isEmpty = false;
            newData.data = DataTableMgr.Get<CharacterTable>(DataTableIds.character).Get("Char3");
            charDataList[2] = newData;
        }
        uiCharSlot.SetData(charDataList[2]);
        currentSlotIndex = 2;
        EquipSlotUpdate();

    }
    public void SetBard()
    {
        if (charDataList[3].isEmpty)
        {
            var newData = new SaveCharacterData();
            newData.isEmpty = false;
            newData.data = DataTableMgr.Get<CharacterTable>(DataTableIds.character).Get("Char4");
            charDataList[3] = newData;
        }
        uiCharSlot.SetData(charDataList[3]);
        currentSlotIndex = 3;
        EquipSlotUpdate();

    }

    public void InventoryOpen(int buttonIndex)
    {
        Button clickedButton = buttons[buttonIndex];
        currentButton = clickedButton;
        buttonCount = buttonIndex + 1;
        CharacterPannel.SetActive(false);
        InventoryPannel.SetActive(true);
    }

    public void EquipSlotUpdate()
    {
        var currendata = charDataList[currentSlotIndex];
        currendata.Attack = 0;
        currendata.Diffence = 0;
        if (currendata.equip1 != null)
        {
            buttons[0].image.sprite = currendata.equip1.GetSprite;
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;

            if (currendata.equip1.Type == "Weapon")
            {
                currendata.Attack += currendata.equip1.Value;
            }
            else if (currendata.equip1.Type == "Equip")
            {
                currendata.Diffence += currendata.equip1.Value;
            }
        }
        else
        {
            buttons[0].image.sprite = null;
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Empty";

        }
        if (currendata.equip2 != null)
        {
            buttons[1].image.sprite = currendata.equip2.GetSprite;
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;

            if (currendata.equip2.Type == "Weapon")
            {
                currendata.Attack += currendata.equip2.Value;
            }
            else if (currendata.equip2.Type == "Equip")
            {
                currendata.Diffence += currendata.equip2.Value;
            }
        }
        else
        {
            buttons[1].image.sprite = null;
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Empty";
        }
        if (currendata.equip3 != null)
        {
            buttons[2].image.sprite = currendata.equip3.GetSprite;
            buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;

            if (currendata.equip3.Type == "Weapon")
            {
                currendata.Attack += currendata.equip3.Value;
            }
            else if (currendata.equip3.Type == "Equip")
            {
                currendata.Diffence += currendata.equip3.Value;
            }
        }
        else
        {
            buttons[2].image.sprite = null;
            buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = "Empty";
        }

        charDataList[currentSlotIndex].Attack = currendata.Attack;
        charDataList[currentSlotIndex].Diffence = currendata.Diffence;
        uiCharSlot.SetData(charDataList[currentSlotIndex]);

    }
}
