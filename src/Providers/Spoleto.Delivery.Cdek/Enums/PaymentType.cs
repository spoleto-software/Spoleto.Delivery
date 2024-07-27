using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип оплаты.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<PaymentType>))]
    public enum PaymentType
    {
        /// <summary>
        /// Картой.
        /// </summary>
        [Description("картой")]
        [JsonEnumValue("CARD")]
        Card,

        /// <summary>
        /// Наличными.
        /// </summary>
        [Description("Наличными")]
        [JsonEnumValue("CASH")]
        Cash
    }
}
