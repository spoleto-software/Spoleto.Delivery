using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о webhook.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29934408.html"/>
    /// </remarks>
    public record Webhook
    {
        /// <summary>
        /// Получает или задает информацию о заказе.
        /// </summary>
        [JsonPropertyName("entity")]
        public WebhookEntity Entity { get; set; }

        /// <summary>
        /// Получает или задает информацию о запросе над заказом.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryRequestInfo>? Requests { get; set; }
    }
}