using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о подписке.
    /// </summary>
    public record WebhookEntity : WebhookEntityBase
    {
        /// <summary>
        /// URL, на который клиенту приходят вебхуки.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Тип события.
        /// </summary>
        [JsonPropertyName("type")]
        public WebhookType Type { get; set; }
    }
}