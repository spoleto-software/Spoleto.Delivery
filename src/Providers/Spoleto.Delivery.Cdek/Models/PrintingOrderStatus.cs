using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус квитанции.
    /// </summary>
    public record PrintingOrderStatus
    {
        /// <summary>
        /// Идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("code")]
        public PrintingOrderStatusCode Code { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Дата и время установки статуса.
        /// </summary>
        [JsonPropertyName("date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DateTime { get; set; }
    }
}
