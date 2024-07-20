using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost.Converters
{
    public class JsonDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            var str = reader.GetString();
            if (str == string.Empty)
                return default;

            var dt = DateTime.Parse(str!, CultureInfo.InvariantCulture);
            return dt;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.Value);
        }
    }
}
