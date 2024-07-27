using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о прозвонах получателя
    /// </summary>
    public record CallInfo
    {
        /// <summary>
        /// Информация о неуспешных прозвонах (недозвонах)
        /// </summary>
        [JsonPropertyName("failed_calls")]
        public List<FailedCall>? FailedCalls { get; set; }

        /// <summary>
        /// Информация о переносах прозвонов
        /// </summary>
        [JsonPropertyName("rescheduled_calls")]
        public List<RescheduledCall>? RescheduledCalls { get; set; }
    }
}