using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Оплата за товар.
    /// </summary>
    public record DeliveryItemPayment
    {
        /// <summary>
        /// Сумма наложенного платежа, в том числе и НДС (в случае предоплаты = 0).
        /// </summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Сумма НДС.
        /// </summary>
        [JsonPropertyName("vat_sum")]
        public decimal? VatSum { get; set; }

        /// <summary>
        /// Ставка НДС (значение - 0, 10, 12, 20, null - нет НДС).
        /// </summary>
        [JsonPropertyName("vat_rate")]
        [JsonConverter(typeof(JsonIntConverter))]
        public int? VatRate { get; set; }
    }
}