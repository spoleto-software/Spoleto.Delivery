using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record DeliveryOrder
    {
        /// <summary>
        /// Информация о заказе.
        /// </summary>
        [JsonPropertyName("entity")]
        public DeliveryOrderEntity Entity { get; set; } //todo: additional services extend enum items

        /// <summary>
        /// Список запросов над заказом.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryOrderRequestInfo> Requests { get; set; }

        /// <summary>
        /// Связанные с заказом сущности.
        /// </summary>
        [JsonPropertyName("related_entities")]
        public List<DeliveryOrderRelatedEntity>? RelatedEntities { get; set; }
    }
}
