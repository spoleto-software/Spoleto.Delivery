using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Список тарифов доставки.
    /// </summary>
    internal record TariffList
    {
        /// <summary>
        /// Доступные тарифы
        /// </summary>
        [JsonPropertyName("tariff_codes")]
        public List<Tariff> Tariffs { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        [JsonPropertyName("errors")]
        public List<Error>? Errors { get; set; }
    }
}
