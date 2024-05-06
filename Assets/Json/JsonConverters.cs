using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

public class SaveItemDataConverter : JsonConverter<SaveItemData>
{
    public override SaveItemData ReadJson(JsonReader reader, Type objectType, SaveItemData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var data = new SaveItemData();
        JObject jObj = JObject.Load(reader);
        data.instanceId = (int)jObj["instanceId"];
        var itemId = (string)jObj["dataId"];
        data.data = DataTableMgr.Get<ItemTable>(DataTableIds.Item).Get(itemId);
        data.customOrder = (int)jObj["customOrder"];
        data.creationTime = (System.DateTime)jObj["creationTime"];
        return data;
    }


    public override void WriteJson(JsonWriter writer, SaveItemData value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("instanceId");
        writer.WriteValue(value.instanceId);
        writer.WritePropertyName("dataId");
        writer.WriteValue(value.data.Id);
        writer.WritePropertyName("customOrder");
        writer.WriteValue(value.customOrder);
        writer.WritePropertyName("creationTime");
        writer.WriteValue(value.creationTime);
        writer.WriteEndObject();
    }


}


public class Vector3Converter : JsonConverter<Vector3>
{

    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Vector3 v = Vector3.zero;
        JObject jObj = JObject.Load(reader);
        v.x = (float)jObj["X"];
        v.y = (float)jObj["Y"];
        v.z = (float)jObj["Z"];
        return v;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
        writer.WriteEndObject();
    }
}


public class QuaternionConverter : JsonConverter<Quaternion>
{
    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Quaternion rot  = Quaternion.identity;
        JObject jObj = JObject.Load(reader);
        rot.x = (float)jObj["X"];
        rot.y = (float)jObj["Y"];
        rot.z = (float)jObj["Z"];
        rot.w = (float)jObj["W"];
        return rot;
    }

    public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
        writer.WritePropertyName("W");
        writer.WriteValue(value.w);
        writer.WriteEndObject();
    }
}

public class ColorConverter : JsonConverter<Color>
{
    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Color color;
        JObject jObj = JObject.Load(reader);
        color.r = (float)jObj["R"];
        color.g = (float)jObj["G"];
        color.b = (float)jObj["B"];
        color.a = (float)jObj["A"];
        return color;
    }

    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("R");
        writer.WriteValue(value.r);
        writer.WritePropertyName("G");
        writer.WriteValue(value.g);
        writer.WritePropertyName("B");
        writer.WriteValue(value.b);
        writer.WritePropertyName("A");
        writer.WriteValue(value.a);
        writer.WriteEndObject();
    }
}
