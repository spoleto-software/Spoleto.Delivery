using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о вручении.
    /// </summary>
    public record DeliveryDetail
    {
        /// <summary>
        /// Дата доставки.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Получатель при доставке.
        /// </summary>
        [JsonPropertyName("recipient_name")]
        public string? RecipientName { get; set; }

        /// <summary>
        /// Сумма наложенного платежа, которую взяли с получателя, в валюте страны получателя с учетом частичной доставки.
        /// </summary>
        [JsonPropertyName("payment_sum")]
        public decimal? PaymentSum { get; set; }

        /// <summary>
        /// Тип оплаты наложенного платежа получателем.
        /// </summary>
        [JsonPropertyName("payment_info")]
        public List<PaymentInfo>? PaymentInfo { get; set; }

        /// <summary>
        /// Стоимость услуги доставки (по тарифу).
        /// </summary>
        [JsonPropertyName("delivery_sum")]
        public decimal DeliverySum { get; set; }

        /// <summary>
        /// Итоговая стоимость заказа.
        /// </summary>
        [JsonPropertyName("total_sum")]
        public decimal TotalSum { get; set; }

        /// <summary>
        /// Процент НДС для расчёта доставки.
        /// </summary>
        [JsonPropertyName("delivery_vat_rate")]
        public int? DeliveryVatRate { get; set; }

        /// <summary>
        /// Сумма НДС для доставки.
        /// </summary>
        [JsonPropertyName("delivery_vat_sum")]
        public decimal? DeliveryVatSum { get; set; }

        /// <summary>
        /// Процент скидки для расчёта доставки.
        /// </summary>
        [JsonPropertyName("delivery_discount_percent")]
        public decimal? DeliveryDiscountPercent { get; set; }

        /// <summary>
        /// Сумма скидки для доставки.
        /// </summary>
        [JsonPropertyName("delivery_discount_sum")]
        public decimal? DeliveryDiscountSum { get; set; }
    }
}