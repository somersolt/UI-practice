using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveData
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();
}

public class SaveDataV1 : SaveData
{
    public int Gold { get; set; } = 100;

    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV2();
        data.Gold = Gold;
        return data;
    }
}

public class SaveDataV2 : SaveData
{
    public int Gold { get; set; } = 100;
    public string Name { get; set; } = "Empty";

    public SaveDataV2()
    {
        Version = 2;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV3();
        data.Gold = Gold;
        return data;
    }
}

public class SaveDataV3 : SaveData
{
    public int Gold { get; set; } = 100;

    public Vector3 Position { get; set; } = Vector3.zero;
    public Quaternion Rotation { get; set; } = Quaternion.identity;
    public Vector3 Scale { get; set; } = Vector3.one;
    public Color color { get; set; } = Color.white;

    public Vector3 Uivalue {  get; set; } = Vector3.zero;

    public SaveDataV3()
    {
        Version = 3;
    }

    public override SaveData VersionUp()
    {
        return null;
    }
}


