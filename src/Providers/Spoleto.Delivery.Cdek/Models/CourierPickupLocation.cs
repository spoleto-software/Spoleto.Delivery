using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления локации (местоположения) для оформления заявки на вызов курьера на забор груза.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29925274.html"/>
    /// </remarks>
    public record CourierPickupLocation 
    {
        /// <summary>
        /// Код населенного пункта СДЭК (метод "Список населенных пунктов")
        /// </summary>
        [JsonPropertyName("code")]
        public int? CityCode { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС.
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Почтовый индекс
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
        /// Код страны в формате ISO_3166-1_alpha-2 (по умолчанию RU)
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
        /// Код региона, уточняющий параметр для поля <see cref="City"/>.
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
        /// Название города
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Код КЛАДР
        /// </summary>
        [JsonPropertyName("kladr_code")]
        public string? KladrCode { get; set; }

        /// <summary>
        /// Полная строка адреса
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
