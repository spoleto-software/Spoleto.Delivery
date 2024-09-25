using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о созданном заказе/заявке.
    /// </summary>
    public record CreatedDeliveryEntity
    {
        /// <summary>
        /// Получает или задает идентификатор заказа/заявки в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}
