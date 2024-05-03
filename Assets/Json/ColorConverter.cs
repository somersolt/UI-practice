using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

[Serializable]
public class ColorConverter : JsonConverter<Color>
{
    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Color v = Color.clear;
        JObject jObj = JObject.Load(reader);
        v.r = (float)jObj["R"];
        v.g = (float)jObj["G"];
        v.b = (float)jObj["B"];
        v.a = (float)jObj["A"];
        
        return v;
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
