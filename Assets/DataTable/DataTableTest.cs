using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using TMPro;

public class DataTableTest : MonoBehaviour
{
    public TextMeshProUGUI text;
    StringTable stringTable;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < DataTableIds.String.Length; i++) {
        //    stringTable = DataTableManager.Get<StringTable>(DataTableIds.String[i]);
        //    Debug.Log(stringTable.Get("HELLO"));
        //}
    }


    public void KR()
    {
        stringTable = DataTableManager.Get<StringTable>(DataTableIds.String[(int)Languages.Korean]);
    }
    public void EN()
    {
        stringTable = DataTableManager.Get<StringTable>(DataTableIds.String[(int)Languages.English]);
    }
    public void JP()
    {
        stringTable = DataTableManager.Get<StringTable>(DataTableIds.String[(int)Languages.Japanese]);
    }
    public void HELLO()
    {
        text.text = stringTable.Get("HELLO");
    }
    public void BYE()
    {
        text.text = stringTable.Get("BYE");
    }
    public void YOUDIE()
    {
        text.text = stringTable.Get("YOU DIE");
    }
    public void TITLE()
    {
        text.text = stringTable.Get("TITLE");
    }
}
