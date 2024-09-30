using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    public record Tariff
    {
        /// <summary>
        /// Название тарифа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость доставки за заказ.
        /// </summary>
        [JsonPropertyName("DN_DEL_COST")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Срок доставки минимум (дата).
        /// </summary>
        [JsonPropertyName("DN_DELDATEMIN")]
        public DateTime? DeliveryMinDateTime { get; set; }

        /// <summary>
        /// Срок доставки максимум (дата).
        /// </summary>
        [JsonPropertyName("DN_DELDATEMAX")]
        public DateTime? DeliveryMaxDateTime { get; set; }

        /// <summary>
        /// Срок доставки минимум (число).
        /// </summary>
        [JsonPropertyName("DN_DELTIMEMIN")]
        public int? DeliveryMinDays { get; set; }

        /// <summary>
        /// Срок доставки максимум (Число).
        /// </summary>
        [JsonPropertyName("DN_DELTIMEMAX")]
        public int? DeliveryMaxDays { get; set; }

        /// <summary>
        /// Услуги
        /// </summary>
        [JsonPropertyName("RATE")]
        public List<TariffRate> Rates { get; set; }
    }
}
