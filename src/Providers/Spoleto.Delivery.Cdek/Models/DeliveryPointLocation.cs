using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Адрес офиса
    /// </summary>
    public record DeliveryPointLocation
    {
        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2 (2 символа).
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Код региона СДЭК.
        /// </summary>
        [JsonPropertyName("region_code")]
        public int RegionCode { get; set; }

        /// <summary>
        /// Название региона.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Код населенного пункта СДЭК.
        /// </summary>
        [JsonPropertyName("city_code")]
        public int CityCode { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Код города ФИАС (UUID).
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Почтовый индекс (до 6 символов).
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Координаты местоположения (долгота) в градусах.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Координаты местоположения (широта) в градусах.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Адрес (улица, дом, офис) в указанном городе.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Полный адрес с указанием страны, региона, города и т.д..
        /// </summary>
        [JsonPropertyName("address_full")]
        public string AddressFull { get; set; }

        /// <summary>
        /// Идентификатор города (UUID).
        /// </summary>
        [JsonPropertyName("city_uuid")]
        public Guid? CityUuid { get; set; }
    }
}
