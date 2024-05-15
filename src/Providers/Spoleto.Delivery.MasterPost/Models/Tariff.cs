using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    internal record Tariff
    {
        /// <summary>
        /// Код тарифа.
        /// </summary>
        [JsonPropertyName("tariff_code")]
        public int Code { get; set; }

        /// <summary>
        /// Название тарифа на языке вывода.
        /// </summary>
        [JsonPropertyName("tariff_name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание тарифа на языке вывода.
        /// </summary>
        [JsonPropertyName("tariff_description")]
        public string? Description { get; set; }

        /// <summary>
        /// Режим тарифа.
        /// </summary>
        [JsonPropertyName("delivery_mode")]
        public int DeliveryMode { get; set; }

        /// <summary>
        /// Стоимость доставки.
        /// </summary>
        [JsonPropertyName("delivery_sum")]
        public float DeliverySum { get; set; }

        /// <summary>
        /// Минимальное время доставки (в рабочих днях).
        /// </summary>
        [JsonPropertyName("period_min")]
        public int PeriodMin { get; set; }

        /// <summary>
        /// Максимальное время доставки (в рабочих днях).
        /// </summary>
        [JsonPropertyName("period_max")]
        public int PeriodMax { get; set; }

        /// <summary>
        /// Минимальное время доставки (в календарных днях).
        /// </summary>
        [JsonPropertyName("calendar_min")]
        public int? CalendarMin { get; set; }

        /// <summary>
        /// Максимальное время доставки (в календарных днях).
        /// </summary>
        [JsonPropertyName("calendar_max")]
        public int? CalendarMax { get; set; }
    }
}
