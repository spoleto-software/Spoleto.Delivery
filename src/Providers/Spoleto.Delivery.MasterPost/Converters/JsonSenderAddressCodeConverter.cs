using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost.Converters
{
    internal class JsonSenderAddressCodeConverter : JsonConverter<List<string>?>
    {
        public override List<string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                return string.IsNullOrEmpty(value) ? null : new List<string> { value };
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var result = new List<string>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        break;
                    }

                    if (reader.TokenType == JsonTokenType.String)
                    {
                        result.Add(reader.GetString());
                    }
                    else
                    {
                        throw new JsonException();
                    }
                }

                return result;
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, List<string>? value, JsonSerializerOptions options)
        {
            if (value == null || value.Count == 0)
            {
                writer.WriteStringValue(string.Empty);
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in value)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
        }
    }
}
