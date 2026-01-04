using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Доп. сбор за доставку (которую ИМ берет с получателя) в зависимости от суммы заказа.
    /// </summary>
    public record DeliveryRecipientCostAdv
    {
        /// <summary>
        /// Порог стоимости товара (действует по условию меньше или равно) в целых единицах валюты.
        /// </summary>
        [JsonPropertyName("threshold")]
        public int Threshold { get; set; }

        /// <summary>
        /// Доп. сбор за доставку товаров, общая стоимость которых попадает в интервал (в том числе и НДС).
        /// </summary>
        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }

        /// <summary>
        /// Сумма НДС, включённая в доп. сбор за доставку.
        /// </summary>
        [JsonPropertyName("vat_sum")]
        public decimal? VatSum { get; set; }

        /// <summary>
        /// Ставка НДС (значение - 0, 10, 12, 20, 22, null - нет НДС).
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public int? VatRate { get; set; }
    }
}
