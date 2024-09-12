using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery point request.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/36982648.html"/>
    /// </remarks>
    public record DeliveryPointRequest
    {
        /// <summary>
        /// Почтовый индекс города, для которого необходим список офисов.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public int? PostalCode { get; set; }

        /// <summary>
        /// Код населенного пункта СДЭК (метод "Список населенных пунктов").
        /// </summary>
        [JsonPropertyName("city_code")]
        public int? CityCode { get; set; }

        /// <summary>
        /// Тип офиса. Может принимать значения: "PVZ", "POSTAMAT", "ALL".
        /// По умолчанию "ALL".
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<DeliveryPointType>))]
        public DeliveryPointType? Type { get; set; }

        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Код региона по базе СДЭК.
        /// </summary>
        [JsonPropertyName("region_code")]
        public int? RegionCode { get; set; }

        /// <summary>
        /// Наличие терминала оплаты. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("have_cashless")]
        public bool? HaveCashless { get; set; }

        /// <summary>
        /// Есть прием наличных. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("have_cash")]
        public bool? HaveCash { get; set; }

        /// <summary>
        /// Разрешен наложенный платеж. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("allowed_cod")]
        public bool? AllowedCod { get; set; }

        /// <summary>
        /// Наличие примерочной. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("is_dressing_room")]
        public bool? IsDressingRoom { get; set; }

        /// <summary>
        /// Максимальный вес в кг, который может принять офис.
        /// </summary>
        /// <remarks>
        /// Значения больше 0 - передаются офисы, которые принимают этот вес; 0 - офисы с нулевым весом не передаются; значение не указано - все офисы.
        /// </remarks>
        [JsonPropertyName("weight_max")]
        public int? WeightMax { get; set; }

        /// <summary>
        /// Минимальный вес в кг, который принимает офис.
        /// </summary>
        /// <remarks>
        /// При переданном значении будут выводиться офисы с минимальным весом до указанного значения.
        /// </remarks>
        [JsonPropertyName("weight_min")]
        public int? WeightMin { get; set; }

        /// <summary>
        /// Локализация офиса. По умолчанию "rus" (доступны eng и zho).
        /// </summary>
        [JsonPropertyName("lang")]
        [JsonConverter(typeof(JsonEnumValueConverter<Language>))]
        public Language? Lang { get; set; }

        /// <summary>
        /// Является ли офис только пунктом выдачи. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("take_only")]
        public bool? TakeOnly { get; set; }

        /// <summary>
        /// Является пунктом выдачи. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("is_handout")]
        public bool? IsHandout { get; set; }

        /// <summary>
        /// Есть ли в офисе прием заказов. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("is_reception")]
        public bool? IsReception { get; set; }

        /// <summary>
        /// Код города ФИАС.
        /// </summary>
        [JsonPropertyName("fias_guid")]
        public Guid? FiasGuid { get; set; }

        /// <summary>
        /// Код ПВЗ.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// Работает ли офис с LTL (сборный груз). Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("is_ltl")]
        public bool? IsLtl { get; set; }

        /// <summary>
        /// Работает ли офис с "Фулфилмент. Приход". Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        [JsonPropertyName("fulfillment")]
        public bool? Fulfillment { get; set; }

        /// <summary>
        /// Ограничение выборки результата (размер страницы).
        /// </summary>
        [JsonPropertyName("size")]
        public int? Size { get; set; }

        /// <summary>
        /// Номер страницы выборки результата. По умолчанию 0.
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }
    }
}