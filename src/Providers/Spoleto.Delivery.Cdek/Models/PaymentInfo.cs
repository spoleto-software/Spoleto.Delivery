using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип оплаты наложенного платежа получателем.
    /// </summary>
    public record PaymentInfo
    {
        /// <summary>
        /// Тип оплаты (CARD - картой, CASH - наличными).
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<PaymentType>))]
        public PaymentType Type { get; set; }

        /// <summary>
        /// Сумма в валюте страны получателя.
        /// </summary>
        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }
    }
}