using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek.Converters
{
    public class JsonIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var num = reader.GetDecimal();

            return (int)num;
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
