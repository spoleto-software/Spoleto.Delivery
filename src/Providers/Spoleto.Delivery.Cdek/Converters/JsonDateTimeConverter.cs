using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek.Converters
{
    public class JsonDateTimeConverter : JsonDateTimeConverterBase
    {
        public JsonDateTimeConverter() : base("yyyy-MM-ddTHH:mm:sszz00")
        {
        }
    }
}
