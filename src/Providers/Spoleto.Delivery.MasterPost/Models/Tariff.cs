using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    public record Tariff
    {
        /// <summary>
        /// Название тарифа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость доставки за заказ
        /// </summary>
        [JsonPropertyName("DN_DEL_COST")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Услуги
        /// </summary>
        [JsonPropertyName("RATE")]
        public List<TariffRate> Rates { get; set; }
    }
}
