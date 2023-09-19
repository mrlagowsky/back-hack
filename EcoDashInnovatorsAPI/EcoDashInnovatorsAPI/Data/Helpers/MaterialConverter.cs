using EcoDashInnovatorsAPI.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EcoDashInnovatorsAPI.Data.Helpers;

public class MaterialConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<Material>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var materials = new List<Material>();

            JArray array = JArray.Load(reader);
            foreach (var item in array)
            {
                if (item.Type == JTokenType.String)
                {
                    string value = item.Value<string>();
                    if (Enum.TryParse(typeof(Material), value, out var material))
                    {
                        materials.Add((Material)material);
                    }
                }
            }

            return materials;
        }

        return existingValue;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is List<Material> materials)
        {
            writer.WriteStartArray();
            foreach (var material in materials)
            {
                var enumName = Enum.GetName(typeof(Material), material);
                writer.WriteValue(enumName);
            }
            writer.WriteEndArray();
        }
    }
}