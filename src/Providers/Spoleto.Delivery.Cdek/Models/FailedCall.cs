using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о неуспешном прозвоне (недозвоне)
    /// </summary>
    public record FailedCall
    {
        /// <summary>
        /// Дата и время создания недозвона
        /// </summary>
        [JsonPropertyName("date_time")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Причина недозвона (подробнее см. приложение 5)
        /// </summary>
        [JsonPropertyName("reason_code")]
        public int ReasonCode { get; set; } //todo: enum
    }
}