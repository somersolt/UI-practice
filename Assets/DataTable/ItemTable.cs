using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemData
{

    public static readonly string FormatIconPath = "Icons/Item/{0}";
    public string Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }

    public string GetType
    {
        get
        {
            return DataTableManager.GetStringTable().Get(Type);
        }

    }
    public string GetName
    {
        get
        {
            return DataTableManager.GetStringTable().Get(Name);
        }
    }

    public string GetDesc
    {
        get
        {
            return DataTableManager.GetStringTable().Get(Desc);
        }

    }

    public Sprite GetSprite
    {
        get
        {
            return Resources.Load<Sprite>(string.Format(FormatIconPath, Icon));
        }
    }

    public override string ToString()
    {
        return $"{Id}: {Type} / {GetName} / {GetDesc} / {Value} / {Cost} / {GetSprite}";
    }
}
public class ItemTable : DataTable
{
    private Dictionary<string, ItemData> table = new Dictionary<string, ItemData> ();

    public List<string> AllItemIds
    {
        get
        {
            return table.Keys.ToList();
        }
    }

    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        { return null; }
        return table[id];
    }
    public override void Load(string path)
    {
        path = string.Format(FormatPath, path);

        TextAsset textAsset = Resources.Load<TextAsset>(path);

        using (var reader = new StringReader(textAsset.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<ItemData>();
            foreach (var record in records)
            {
                table.Add(record.Id, record);
                Debug.Log(record);
            }
        }
    }
}
