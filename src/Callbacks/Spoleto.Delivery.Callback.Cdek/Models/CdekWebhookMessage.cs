using System.Text.Json.Serialization;
using Spoleto.Delivery.Callback.Cdek.Converters;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// СДЭК вэбхук.
    /// </summary>
    public record CdekWebhookMessage<T> where T: ICdekWebhookContent
    {
        /// <summary>
        /// Тип события.
        /// </summary>
        [JsonPropertyName("type")]
        public CdekWebhookMessageType Type { get; set; }

        /// <summary>
        /// Дата и время установки нового статуса в формате ISO 8601.
        /// </summary>
        [JsonPropertyName("date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Идентификатор сущности (заказ, печатная форма, фото документов и т.д.).
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Атрибуты события.
        /// </summary>
        [JsonPropertyName("attributes")]
        public T Attributes { get; set; }
    }
}
