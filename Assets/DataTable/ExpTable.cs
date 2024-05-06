using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class ExpData
{
    public int Level { get; set; }
    public int Next { get; set; }
}

public class ExpTable : DataTable
{
    private Dictionary<int, ExpData> table = new Dictionary<int, ExpData>();

    public List<int> AllItemIds
    {
        get
        {
            return table.Keys.ToList();
        }
    }

    public int Get(int level)
    {
        if (!table.ContainsKey(level))
            return 0;

        return table[level].Next;
    }
           
    public override void Load(string path)
    {
        path = string.Format(FormatPath, path);

        var textAsset = Resources.Load<TextAsset>(path);

        using (var reader = new StringReader(textAsset.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<ExpData>();
            foreach (var record in records)
            {
                table.Add(record.Level, record);
            }
        }
    }
}

