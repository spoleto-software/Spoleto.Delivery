using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация по местам (упаковкам).
    /// </summary>
    public record DeliveryOrderPackage : DeliveryOrderPackageBase
    {
        /// <summary>
        /// Уникальный номер упаковки в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("package_id")]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Объемный вес (в граммах).
        /// </summary>
        [JsonPropertyName("weight_volume")]
        public int? WeightVolume { get; set; }

        /// <summary>
        /// Расчетный вес (в граммах).
        /// </summary>
        [JsonPropertyName("weight_calc")]
        public int? WeightCalc { get; set; }

        /// <summary>
        /// Позиции товаров в упаковке
        /// </summary>
        [JsonPropertyName("items")]
        public List<DeliveryPackageItem>? Items { get; set; }
    }
}
