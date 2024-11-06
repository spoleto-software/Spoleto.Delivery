using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Исключения в графике работы офиса 
    /// </summary>
    [Obsolete]
    public record WorkTimeExceptionLegacy
    {
        /// <summary>
        /// Дата (в формате ISO 8601: YYYY-MM-DD).
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Период работы в указанную дату. Если в этот день не работают, то не отображается.
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; }

        /// <summary>
        /// Признак рабочего/нерабочего дня в указанную дату.
        /// </summary>
        [JsonPropertyName("is_working")]
        public bool IsWorking { get; set; }
    }
}