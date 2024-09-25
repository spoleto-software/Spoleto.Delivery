using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Created Cdek courier pickup order.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29925274.html"/>
    /// </remarks>
    public record CreatedCourierPickup
    {
        /// <summary>
        /// Получает или задает информацию о заявке.
        /// </summary>
        [JsonPropertyName("entity")]
        public CreatedDeliveryEntity Entity { get; set; }

        /// <summary>
        /// Получает или задает информацию о запросе над заявкой.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryRequestInfo> Requests { get; set; }
    }
}
