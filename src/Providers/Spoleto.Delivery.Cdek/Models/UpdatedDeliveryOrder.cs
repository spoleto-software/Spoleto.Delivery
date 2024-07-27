using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Updated Cdek delivery order.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/36981178.html"/>
    /// </remarks>
    public record UpdatedDeliveryOrder
    {
        /// <summary>
        /// Получает или задает информацию о заказе.
        /// </summary>
        [JsonPropertyName("entity")]
        public UpdatedDeliveryOrderEntity Entity { get; set; }

        /// <summary>
        /// Получает или задает информацию о запросе над заказом.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryOrderRequestInfo> Requests { get; set; }

    }
}
