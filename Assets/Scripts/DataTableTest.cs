using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using System;

public class DataTableTest : MonoBehaviour
{

    private void Start()
    {
        for (int i = 0; i < 3; ++i)
        {
            var stringTable = DataTableMgr.Get<StringTable>(DataTableIds.String[i]);
            Debug.Log(stringTable.Get("HELLO"));
        }

        // ¾È³ç
        // Hi
        // ???

    }

}

