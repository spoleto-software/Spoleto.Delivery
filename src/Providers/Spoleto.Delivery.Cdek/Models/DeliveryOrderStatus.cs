using System.Text.Json.Serialization;
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
        public string Code { get; set; } //todo: enum?

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
        public string? ReasonCode { get; set; } // todo: enum?

        /// <summary>
        /// Наименование места возникновения статуса.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}