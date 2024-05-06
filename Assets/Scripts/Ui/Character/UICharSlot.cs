using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICharSlot : MonoBehaviour
{

    public Image charIcon;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charLevel;
    public TextMeshProUGUI charJop;
    public TextMeshProUGUI charDesc;
    public TextMeshProUGUI charAttack;
    public TextMeshProUGUI charDiffence;
    public TextMeshProUGUI charExp;

    private List<CharacterData> charDataList = new List<CharacterData>();
    CharacterTable characterTable;
    private List<string> allCharKeys;
    public SaveCharacterData saveCharData { get; set; }

    private void Awake()
    {
        characterTable = DataTableMgr.Get<CharacterTable>(DataTableIds.character);
        allCharKeys = characterTable.AllCharacterIds;
    }
    public void SetEmpty()
    {
        saveCharData = null;

        charIcon.sprite = null;
        charName.text = string.Empty;
        charLevel.text = string.Empty;
        charJop.text = string.Empty;
        charDesc.text = string.Empty;
    }

    public void SetData(SaveCharacterData charData)
    {
        saveCharData = charData;

        charIcon.sprite = charData.data.GetSprite;
        charName.text = charData.data.GetName;
        charLevel.text = charData.Level.ToString();
        charJop.text = charData.data.Jop;
        charDesc.text = charData.data.GetDesc;
        charAttack.text = charData.Attack.ToString();
        charDiffence.text = charData.Diffence.ToString();

    }


}
