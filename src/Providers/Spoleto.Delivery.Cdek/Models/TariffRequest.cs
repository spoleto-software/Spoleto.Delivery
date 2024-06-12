using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Запрос на расчет по доступным тарифам.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    public record TariffRequest
    {
        /// <summary>
        /// Дата и время планируемой передачи заказа, по умолчанию - текущая
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Тип заказа.
        /// </summary>
        /// <remarks>
        /// По умолчанию: <see cref="OrderType.OnlineStore"/>
        /// </remarks>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonIntEnumConverter<OrderType>))]
        public OrderType? Type { get; set; }

        /// <summary>
        /// Дополнительный тип заказа.
        /// </summary>
        [JsonPropertyName("additional_order_types")]
        [JsonConverter(typeof(JsonAdditionalOrderTypeListConverter))]
        public List<AdditionalOrderType>? AdditionalOrderTypes { get; set; }// = new List<AdditionalOrderType> { AdditionalOrderType.LTL, AdditionalOrderType.Forward };

        /// <summary>
        /// Код валюты, в которой необходимо произвести расчет. По умолчанию - валюта договора
        /// </summary>
        [JsonPropertyName("currency")]
        public int? Currency { get; set; }

        /// <summary>
        /// Язык вывода информации о тарифах. Возможные значения: rus, eng, zho. По умолчанию - rus
        /// </summary>
        [JsonPropertyName("lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Адрес отправления
        /// </summary>
        [JsonPropertyName("from_location")]
        public Location FromLocation { get; set; }

        /// <summary>
        /// Адрес получения
        /// </summary>
        [JsonPropertyName("to_location")]
        public Location ToLocation { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам)
        /// </summary>
        [JsonPropertyName("packages")]
        public List<Package> Packages { get; set; }
    }
}
