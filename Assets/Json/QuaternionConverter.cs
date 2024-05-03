using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

[Serializable]
public class QuaternionConverter : JsonConverter<Quaternion>
{
    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Quaternion v = Quaternion.identity;
        JObject jObj = JObject.Load(reader);
        v.x = (float)jObj["X"];
        v.y = (float)jObj["Y"];
        v.z = (float)jObj["Z"];
        v.w = (float)jObj["W"];

        return v;
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
