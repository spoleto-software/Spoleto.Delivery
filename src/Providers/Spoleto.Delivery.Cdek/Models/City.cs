using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record City
    {
        /// <summary>
        /// Код населенного пункта СДЭК.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Идентификатор города в ИС СДЭК
        /// </summary>
        [JsonPropertyName("city_uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Название населенного пункта.
        /// </summary>
        [JsonPropertyName("city")]
        public string Name { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС населенного пункта.
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Код КЛАДР населенного пункта.
        /// </summary>
        /// <remarks>
        /// Устаревшее поле.
        /// </remarks>
        [JsonPropertyName("kladr_code")]
        public string? KladrCode { get; set; }

        /// <summary>
        /// Код страны населенного пункта в формате  ISO_3166-1_alpha-2.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Название страны населенного пункта.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Название региона населенного пункта.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Код региона СДЭК.
        /// </summary>
        [JsonPropertyName("region_code")]
        public int? RegionCode { get; set; }

        /// <summary>
        /// Долгота центра населенного пункта.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Широта центра населенного пункта.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Часовой пояс населенного пункта.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Ограничение на сумму наложенного платежа в населенном пункте.
        /// </summary>
        [JsonPropertyName("payment_limit")]
        public double? PaymentLimit { get; set; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        [JsonPropertyName("errors")]
        public Error[]? Errors { get; set; }
    }
}
