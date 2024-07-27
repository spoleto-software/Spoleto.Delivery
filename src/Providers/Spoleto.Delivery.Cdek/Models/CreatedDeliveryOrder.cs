using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Created Cdek delivery order.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923926.html"/>
    /// </remarks>
    public record CreatedDeliveryOrder
    {
        /// <summary>
        /// Получает или задает информацию о заказе.
        /// </summary>
        [JsonPropertyName("entity")]
        public CreatedDeliveryOrderEntity Entity { get; set; }

        /// <summary>
        /// Получает или задает информацию о запросе над заказом.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryOrderRequestInfo> Requests { get; set; }

        /// <summary>
        /// Получает или задает связанные сущности (если в запросе был передан корректный print).
        /// </summary>
        [JsonPropertyName("related_entities")]
        public List<CreatedDeliveryOrderRelatedEntity>? RelatedEntities { get; set; }
    }
}
