using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Стоимость услуги доставки.
    /// </summary>
    public record DeliveryOrderRate
    {
        /// <summary>
        /// Вид услуги.
        /// </summary>
        /// <remarks>Вид услуги.</remarks>
        [JsonPropertyName("RATE_PART")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        /// <remarks>Стоимость услуги без НДС. Обязательно одно из двух: или стоимость, или коэффициент.</remarks>
        [JsonPropertyName("RATE_PRICE")]
        public decimal? ServicePrice { get; set; }

        /// <summary>
        /// НДС.
        /// </summary>
        /// <remarks>НДС.</remarks>
        [JsonPropertyName("RATE_VAT")]
        public decimal? ServiceVat { get; set; }

        /// <summary>
        /// Коэффициент.
        /// </summary>
        /// <remarks>Коэффициент услуги. Обязательно одно из двух: или стоимость, или коэффициент.</remarks>
        [JsonPropertyName("RATE_COEF")]
        public decimal? ServiceCoefficient { get; set; }
    }
}
