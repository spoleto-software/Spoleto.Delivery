using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус по заявке на вызов курьера на забор груза.
    /// </summary>
    public record CourierPickupStatus
    {
        /// <summary>
        /// Код статуса (подробнее см. приложение 1).
        /// </summary>
        [JsonPropertyName("code")]
        public PickupStatus Code { get; set; }

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
    }
}