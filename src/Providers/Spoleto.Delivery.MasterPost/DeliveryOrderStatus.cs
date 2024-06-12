using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Статус доставки.
    /// </summary>
    public record DeliveryOrderStatus
    {
        /// <summary>
        /// Статус.
        /// </summary>
        /// <remarks>Статус доставки накладной.</remarks>
        [JsonPropertyName("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// Дата статуса.
        /// </summary>
        /// <remarks>Дата статуса доставки накладной.</remarks>
        [JsonPropertyName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }

        /// <summary>
        /// Комментарий к статусу.
        /// </summary>
        /// <remarks>Комментарий к статусу доставки накладной.</remarks>
        [JsonPropertyName("STATUS_COMM")]
        public string StatusComment { get; set; }
    }
}
