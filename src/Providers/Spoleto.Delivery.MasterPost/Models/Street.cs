using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Улица.
    /// </summary>
    public record Street
    {
        /// <summary>
        /// Наименование улицы.
        /// </summary>
        [JsonPropertyName("STREET")]
        public string Name { get; set; }

        /// <summary>
        /// Код ФИАС для улицы.
        /// </summary>
        [JsonPropertyName("STREET_FIAS")]
        public Guid FiasGuid { get; set; }

        /// <summary>
        /// Код КЛАДР для улицы.
        /// </summary>
        [JsonPropertyName("STREET_KLADR")]
        public string KladrCode { get; set; }

        /// <summary>
        /// Код ФИАС для города.
        /// </summary>
        [JsonPropertyName("CITY_FIAS")]
        public string CityFiasGuid { get; set; }

        /// <summary>
        /// Код КЛАДР для города.
        /// </summary>
        [JsonPropertyName("CITY_KLADR")]
        public string CityKladrCode { get; set; }
    }
}
