using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Запрос на создание webhook.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29934408.html"/>
    /// </remarks>
    public record WebhookRequest
    {
        /// <summary>
        /// URL, на который клиент хочет получать вебхуки.
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