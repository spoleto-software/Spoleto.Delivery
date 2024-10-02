using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о статусе заказа.
    /// </summary>
    public record DeliveryOrderStatus
    {
        /// <summary>
        /// Код статуса.
        /// </summary>
        [JsonPropertyName("code")]
        public OrderStatus Code { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Дата и время установки статуса (формат yyyy-MM-dd'T'HH:mm:ssZ).
        /// </summary>
        [JsonPropertyName("date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Дополнительный код статуса.
        /// </summary>
        [JsonPropertyName("reason_code")]
        [JsonConverter(typeof(JsonIntEnumConverter<OrderAdditionalStatus>))]
        public OrderAdditionalStatus? ReasonCode { get; set; }

        /// <summary>
        /// Наименование места возникновения статуса.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}