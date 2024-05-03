using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;

public static class SaveLoadSystem
{
    public enum Mode
    {
        Json,
        Binary,
        EncryptedBinary, //암호화된 바이너리
    }

    public static Mode FileMode { get; set; } = Mode.Json;

    public static int SaveDataVersion { get; private set; } = 2;

    // 0(자동저장) , 1, 2, 3 슬롯
    private static readonly string[] SaveFileName =
    {
        "SaveAuto.sav",
        "Save1.sav",
        "Save2.sav",
        "Save3.sav",
    };

    private static string SaveDirectory
    {
        get
        {
            return $"{Application.persistentDataPath}/Save";
        }
    }




    public static bool Save(SaveData data, int slot = 0)
    {
        if ( slot < 0 || slot >= SaveFileName.Length )
        {
            return false;
        }

        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        //FileMode 분기

        using (var writer = new JsonTextWriter(new StreamWriter(path)))
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new Vector3Converter());
            serializer.Converters.Add(new ColorConverter());
            serializer.Converters.Add(new QuaternionConverter());
            serializer.TypeNameHandling = TypeNameHandling.All; 
            serializer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, data);
        }

        return true;
    }

    public static SaveData Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileName.Length)
        {
            return null;
        }
        if (!Directory.Exists(SaveDirectory))
        {
            return null;
        }

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        SaveData data = null;
        using (var reader = new JsonTextReader(new StreamReader(path)))
        {
            var deserializer = new JsonSerializer();
            deserializer.Converters.Add(new Vector3Converter());
            deserializer.Converters.Add(new ColorConverter());
            deserializer.Converters.Add(new QuaternionConverter());
            deserializer.TypeNameHandling = TypeNameHandling.All;

            data = deserializer.Deserialize<SaveData>(reader);

        }

        while (data.Version < SaveDataVersion)
        {
            data = data.VersionUp();
        }


        return data;
    }

}
