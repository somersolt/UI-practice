using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class DataTableManager
{
    private static Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();


    static DataTableManager()
    {
        for (int i = 0; i < DataTableIds.String.Length; i++)
        {
            DataTable table = new StringTable();
            table.Load(DataTableIds.String[i]);
            tables.Add(DataTableIds.String[i], table);
        }


        DataTable itemTable = new ItemTable();
        itemTable.Load(DataTableIds.Item);
        tables.Add(DataTableIds.Item, itemTable);
    }

    public static StringTable GetStringTable()
    {
        return Get<StringTable>(DataTableIds.String[(int)Vars.currentLang]);
    }

    
    public static T Get<T>(string id) where T : DataTable
    {
        if(! tables.ContainsKey(id))
            return null;
        return tables[id] as T;
    }
}
