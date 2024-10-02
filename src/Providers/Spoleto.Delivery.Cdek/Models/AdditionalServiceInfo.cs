using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Дополнительная услуга при получении информации о заказе.
    /// </summary>
    public record AdditionalServiceInfo
    {
        /// <summary>
        /// Код услуги.
        /// </summary>
        [JsonPropertyName("code")]
        public AdditionalServiceInfoType Code { get; set; }

        /// <summary>
        /// Параметр дополнительной услуги.
        /// </summary>
        [JsonPropertyName("parameter")]
        public string? Parameter { get; set; }

        /// <summary>
        /// Стоимость услуги (в валюте взаиморасчётов).
        /// </summary>
        [JsonPropertyName("sum")]
        public decimal? Sum { get; set; }

        /// <summary>
        /// Общая сумма (итого с НДС и скидкой в валюте взаиморасчётов).
        /// </summary>
        [JsonPropertyName("total_sum")]
        public decimal TotalSum { get; set; }

        /// <summary>
        /// Процент скидки.
        /// </summary>
        [JsonPropertyName("discount_percent")]
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// Общая сумма скидки.
        /// </summary>
        [JsonPropertyName("discount_sum")]
        public decimal DiscountSum { get; set; }

        /// <summary>
        /// Сумма НДС.
        /// </summary>
        [JsonPropertyName("vat_sum")]
        public decimal VatSum { get; set; }

        /// <summary>
        /// Ставка НДС.
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public int? VatRate { get; set; }
    }
}
