using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Запрос для получения списка населенных пунктов.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/33829437.html"/>
    /// </remarks>
    public record CityRequest
    {
        /// <summary>
        /// Массив кодов стран в формате ISO_3166-1_alpha-2.
        /// </summary>
        [JsonPropertyName("country_codes")]
        public string[] CountryCodes { get; set; }

        /// <summary>
        /// Код региона СДЭК.
        /// </summary>
        [JsonPropertyName("region_code")]
        public int? RegionCode { get; set; }

        /// <summary>
        /// Код КЛАДР региона (устаревшее поле).
        /// </summary>
        [JsonPropertyName("kladr_region_code")]
        public string KladrRegionCode { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС региона (устаревшее поле).
        /// </summary>
        [JsonPropertyName("fias_region_guid")]
        public Guid? FiasRegionGuid { get; set; }

        /// <summary>
        /// Код КЛАДР населенного пункта (устаревшее поле).
        /// </summary>
        [JsonPropertyName("kladr_code")]
        public string KladrCode { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС населенного пункта.
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasGuid { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Код населенного пункта СДЭК.
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        /// <summary>
        /// Название населенного пункта. Должно соответствовать полностью.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Ограничение выборки результата. По умолчанию 1000.
        /// </summary>
        [JsonPropertyName("size")]
        public int? Size { get; set; }

        /// <summary>
        /// Номер страницы выборки результата. По умолчанию 0.
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Язык локализации ответа.
        /// </summary>
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// Ограничение на сумму наложенного платежа:
        /// -1 - ограничения нет;
        /// 0 - наложенный платеж не принимается.
        /// </summary>
        [JsonPropertyName("payment_limit")]
        public float? PaymentLimit { get; set; }
    }
}
