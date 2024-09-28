using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Helpers
{
    internal static class JsonHelper
    {
        private static readonly JavaScriptEncoder _encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        private static readonly JsonSerializerOptions _defaultSerializerOptions;

        static JsonHelper()
        {
            _defaultSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = _encoder,
                WriteIndented = true,
            };
        }

        public static string ToRelaxedIndentedJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _defaultSerializerOptions);
        }
    }
}
