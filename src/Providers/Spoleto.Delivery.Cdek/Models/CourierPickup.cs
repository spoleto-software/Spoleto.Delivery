using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Заявка на вызов курьера на забор груза.
    /// </summary>
    public record CourierPickup
    {
        /// <summary>
        /// Информация о заказе.
        /// </summary>
        [JsonPropertyName("entity")]
        public CourierPickupEntity Entity { get; set; }

        /// <summary>
        /// Список запросов над заказом.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryRequestInfo> Requests { get; set; }
    }
}
