using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost.Converters
{
    public class JsonGuidConverter : JsonConverter<Guid?>
    {
        public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            var str = reader.GetString();
            if (str == string.Empty)
                return default;

            var g = Guid.Parse(str!);
            return g;
        }

        public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.Value);
        }
    }
}
