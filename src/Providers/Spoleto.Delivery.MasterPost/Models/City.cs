using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    internal record City
    {
        /// <summary>
        /// Код ФИАС.
        /// </summary>
        [JsonPropertyName("FIAS")]
        public Guid FiasGuid { get; set; }

        /// <summary>
        /// Код КЛАДР.
        /// </summary>
        [JsonPropertyName("KLADR")]
        public string KladrCode { get; set; }

        /// <summary>
        /// Наименование города.
        /// </summary>
        [JsonPropertyName("CITY")]
        public string Name { get; set; }

        /// <summary>
        /// Наименование страны.
        /// </summary>
        [JsonPropertyName("COUNTRY")]
        public string Country { get; set; }

        /// <summary>
        /// Наименование области города.
        /// </summary>
        [JsonPropertyName("REGION")]
        public string Region { get; set; }
    }
}
