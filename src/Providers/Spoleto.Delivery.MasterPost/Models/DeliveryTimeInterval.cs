using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Временной интервал доставки.
    /// </summary>
    public record DeliveryTimeInterval
    {
        /// <summary>
        /// Временной интервал.
        /// </summary>
        [JsonPropertyName("DEL_TIME")]
        public string DeliveryTime { get; set; }

        /// <summary>
        /// Флаг доставки в вечернее время.
        /// </summary>
        [JsonPropertyName("EVENING_DEL")]
        public bool EveningDelivery { get; set; }
    }
}
