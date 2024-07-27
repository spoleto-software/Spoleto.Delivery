using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о измененном заказе
    /// </summary>
    public record UpdatedDeliveryOrderEntity
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС СДЭК, который был изменен.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid? Uuid { get; set; }
    }
}
