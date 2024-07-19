using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    public record TariffRate
    {
        /// <summary>
        /// Вид услуги
        /// </summary>
        [JsonPropertyName("RATE_PART")]
        public string RatePart { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [JsonPropertyName("RATE_PRICE")]
        public decimal Price { get; set; }

        /// <summary>
        /// НДС
        /// </summary>
        [JsonPropertyName("RATE_VAT")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Коэффициент
        /// </summary>
        [JsonPropertyName("RATE_COEF")]
        public decimal Coefficient { get; set; }
    }
}