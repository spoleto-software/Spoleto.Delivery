using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Тариф
    /// </summary>
    internal record Service
    {
        /// <summary>
        /// Наименование тарифа.
        /// </summary>
        [JsonPropertyName("DEL_MODE")]
        public string DeliveryMode { get; set; }
    }
}
