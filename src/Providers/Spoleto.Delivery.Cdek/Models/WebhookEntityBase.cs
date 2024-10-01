using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о подписке.
    /// </summary>
    public record WebhookEntityBase
    {
        /// <summary>
        /// Получает или задает идентификатор подписки в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}