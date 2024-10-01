using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Callback.Cdek.Converters
{
    public class JsonDateTimeConverter : JsonDateTimeConverterBase
    {
        public JsonDateTimeConverter() : base("yyyy-MM-ddTHH:mm:sszz00")
        {
        }
    }
}
