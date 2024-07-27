using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о созданном заказе
    /// </summary>
    public record CreatedDeliveryOrderEntity
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid? Uuid { get; set; }
    }
}
