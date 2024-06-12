using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek.Converters
{
    public class JsonAdditionalOrderTypeListConverter : JsonConverter<List<AdditionalOrderType>>
    {
        public override List<AdditionalOrderType>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            var enumList = new List<AdditionalOrderType>();

            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    break;

                if (reader.TokenType == JsonTokenType.Number)
                {
                    var enumValue = reader.GetInt32();
                    enumList.Add((AdditionalOrderType)enumValue);
                }
                else
                {
                    throw new JsonException();
                }
            }

            return enumList;
        }

        public override void Write(Utf8JsonWriter writer, List<AdditionalOrderType> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var enumValue in value)
            {
                writer.WriteNumberValue((int)enumValue);
            }
            writer.WriteEndArray();
        }
    }
}
