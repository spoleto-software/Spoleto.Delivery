using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Доп. сбор за доставку, которую ИМ берет с получателя.
    /// </summary>
    public record DeliveryRecipientCost
    {
        /// <summary>
        /// Сумма дополнительного сбора (в том числе и НДС).
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
        public int? VatRate { get; set; }
    }
}
