using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    [JsonConverter(typeof(JsonEnumValueConverter<RequestType>))]
    public enum RequestType
    {
        [JsonEnumValue("CREATE")]
        Create,

        [JsonEnumValue("UPDATE")]
        Update,

        [JsonEnumValue("DELETE")]
        Delete,

        [JsonEnumValue("AUTH")]
        Auth,

        [JsonEnumValue("GET")]
        Get
    }
}
