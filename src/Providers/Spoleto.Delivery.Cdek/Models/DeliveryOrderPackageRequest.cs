using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация по местам (упаковкам).
    /// </summary>
    public record DeliveryOrderPackageRequest : DeliveryOrderPackageBase
    {
        /// <summary>
        /// Позиции товаров в упаковке
        /// </summary>
        /// <remarks>
        /// Только для заказов "интернет-магазин".<br/>
        /// Максимум 126 уникальных позиций в заказе.<br/>
        /// Общее количество товаров в заказе может быть от 1 до 999999.
        /// </remarks>
        [JsonPropertyName("items")]
        public List<DeliveryPackageItemBase>? Items { get; set; }
    }
}
