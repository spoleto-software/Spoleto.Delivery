using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek.Converters
{
    public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
    {
        private readonly string _timeSpanFormat = "hh\\:mm";
        private readonly string _timeSpanSecondsFormat = "hh\\:mm\\:ss";

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString()!;
            if (TimeSpan.TryParseExact(str, _timeSpanFormat, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }

            if (TimeSpan.TryParseExact(str, _timeSpanSecondsFormat, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            return TimeSpan.Parse(str, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_timeSpanFormat));
        }
    }
}
