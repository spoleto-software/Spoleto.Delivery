using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о переносе прозвона
    /// </summary>
    public record RescheduledCall
    {
        /// <summary>
        /// Дата и время создания переноса прозвона
        /// </summary>
        [JsonPropertyName("date_time")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Дата, на которую согласован повторный прозвон
        /// </summary>
        [JsonPropertyName("date_next")]
        public DateTime DateNext { get; set; }

        /// <summary>
        /// Время, на которое согласован повторный прозвон
        /// </summary>
        [JsonPropertyName("time_next")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan TimeNext { get; set; }

        /// <summary>
        /// Комментарий к переносу прозвона
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }
    }
}