using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Исключения в графике работы офиса.
    /// </summary>
    public record WorkTimeException
    {
        /// <summary>
        /// Дата начала исключения в работе офиса.
        /// </summary>
        [JsonPropertyName("date_start")]
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания исключения в работе офиса.
        /// </summary>
        [JsonPropertyName("date_end")]
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Время начала работы в указанную дату
        /// </summary>
        [JsonPropertyName("time_start")]
        public TimeSpan? TimeStart { get; set; }

        /// <summary>
        /// Время окончания работы в указанную дату.
        /// </summary>
        [JsonPropertyName("time_end")]
        public TimeSpan? TimeEnd { get; set; }

        /// <summary>
        /// Признак рабочего/нерабочего дня в указанную дату.
        /// </summary>
        [JsonPropertyName("is_working")]
        public bool IsWorking { get; set; }
    }
}