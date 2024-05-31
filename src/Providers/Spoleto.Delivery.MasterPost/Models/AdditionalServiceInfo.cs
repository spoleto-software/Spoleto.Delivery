using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Информация о Дополнительной услуге.
    /// </summary>
    public record AdditionalServiceInfo
    {
        /// <summary>
        /// Режим доставки.
        /// </summary>
        [JsonPropertyName("DEL_MODE")]
        public string DeliveryMode { get; set; }

        /// <summary>
        /// Дополнительная услуга.
        /// </summary>
        [JsonPropertyName("ADDSERV")]
        public AdditionalService AdditionalService { get; set; }
    }
}
