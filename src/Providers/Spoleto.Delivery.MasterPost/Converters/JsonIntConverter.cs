using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost.Converters
{
    /// <summary>
    /// Custom Json converter for the case when there is "0001-01-01T00:00:00" instead of Int value.
    /// </summary>
    internal class JsonIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            if(reader.TokenType == JsonTokenType.String)
                return default;

            return reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
