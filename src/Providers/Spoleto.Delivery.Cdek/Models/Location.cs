using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления локации (местоположения)
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    public record Location
    {
        /// <summary>
        /// Код населенного пункта СДЭК (метод "Список населенных пунктов")
        /// </summary>
        [JsonPropertyName("code")]
        public int? CityCode { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2 (по умолчанию RU)
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Полная строка адреса
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; set; }
    }
}
