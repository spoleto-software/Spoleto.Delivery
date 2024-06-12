using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Населенный пункт.
    /// </summary>
    public record DeliveryOrderLocation
    {
        /// <summary>
        /// Код населенного пункта СДЭК.
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС.
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasGuid { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Долгота.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Широта.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2 (по умолчанию RU).
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Название региона, уточняющий параметр для поля <see cref="City"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="City"/>.
        ///  </remarks>
        [JsonPropertyName("region")]
        public string? Region { get; set; }

        /// <summary>
        /// Код региона СДЭК, уточняющий параметр для поля <see cref="City"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="City"/>.
        ///  </remarks>
        [JsonPropertyName("region_code")]
        public int? RegionCode { get; set; }

        /// <summary>
        /// Название района региона, уточняющий параметр для поля <see cref="Region"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="Region"/>.
        ///  </remarks>
        [JsonPropertyName("sub_region")]
        public string? SubRegion { get; set; }

        /// <summary>
        /// Название города, уточняющий параметр для <see cref="PostalCode"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="PostalCode"/>.
        ///  </remarks>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Код КЛАДР.
        /// Устаревшее поле.
        /// </summary>
        [JsonPropertyName("kladr_code")]
        public string? KladrCode { get; set; }

        /// <summary>
        /// Строка адреса.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
    } 
}
