using CsvHelper;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

public class CharacterData
{
    public static readonly string FormatIconPath = "Icon/Character/{0}";



    public string Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Jop { get; set; }
    public string Icon { get; set; }

    public string GetName
    {
        get
        {
            return DataTableMgr.GetStringTable().Get(Name);
        }
    }
    public string GetDesc
    {
        get
        {
            return DataTableMgr.GetStringTable().Get(Desc);
        }
    }
    [JsonIgnore]
    public Sprite GetSprite
    {
        get
        {
            return Resources.Load<Sprite>(string.Format(FormatIconPath, Icon));
        }
    }

    public override string ToString()
    {
        return $"{Id}: {GetName} / {GetDesc} / {Jop} /  {GetSprite}";
    }
}

public class CharacterTable : DataTable
{
    private Dictionary<string, CharacterData> table = new Dictionary<string, CharacterData>();

    public List<string> AllCharacterIds
    {
        get
        {
            return table.Keys.ToList();
        }
    }

    public CharacterData Get(string id)
    {
        if (!table.ContainsKey(id))
            return null;

        return table[id];
    }

    public override void Load(string path)
    {
        path = string.Format(FormatPath, path);

        var textAsset = Resources.Load<TextAsset>(path);

        using (var reader = new StringReader(textAsset.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<CharacterData>();
            foreach (var record in records)
            {
                table.Add(record.Id, record);
                Debug.Log(record);
            }
        }
    }
}
