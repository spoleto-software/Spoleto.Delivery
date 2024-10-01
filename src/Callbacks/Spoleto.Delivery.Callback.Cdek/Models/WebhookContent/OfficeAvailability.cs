using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.OFFICE_AVAILABILITY"/>.
    /// </summary>
    public record OfficeAvailability : ICdekWebhookContent
    {
        /// <summary>
        /// Тип офиса по доступности. Может принимать значение:
        /// AVAILABLE_OFFICE (офис доступный)
        /// UNAVAILABLE_OFFICE (офис недоступный)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Код офиса
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
