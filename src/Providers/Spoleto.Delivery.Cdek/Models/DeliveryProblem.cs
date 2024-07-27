using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Проблемы доставки.
    /// </summary>
    public record DeliveryProblem
    {
        /// <summary>
        /// Код проблемы (подробнее см. приложение 4).
        /// </summary>
        [JsonPropertyName("code")]
        [JsonConverter(typeof(JsonIntEnumConverter<DeliveryProblemType>))]
        public DeliveryProblemType Code { get; set; }

        /// <summary>
        /// Дата создания проблемы.
        /// </summary>
        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }
    }
}