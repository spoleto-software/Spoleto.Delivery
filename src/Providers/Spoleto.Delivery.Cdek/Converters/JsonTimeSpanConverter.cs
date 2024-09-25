using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek.Converters
{
    public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
    {
        private readonly string _timeSpanFormat = "hh\\:mm";

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeSpan.ParseExact(reader.GetString()!, _timeSpanFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_timeSpanFormat));
        }
    }
}
