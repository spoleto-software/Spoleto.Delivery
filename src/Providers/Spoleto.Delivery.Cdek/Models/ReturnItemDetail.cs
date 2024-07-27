using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация по товарам в возвратном заказе (только для возвратного заказа).
    /// </summary>
    public record ReturnItemDetail
    {
        /// <summary>
        /// Номер прямого заказа.
        /// </summary>
        [JsonPropertyName("direct_order_number")]
        public string DirectOrderNumber { get; set; }

        /// <summary>
        /// UUID прямого заказа.
        /// </summary>
        [JsonPropertyName("direct_order_uuid")]
        public string DirectOrderUuid { get; set; }

        /// <summary>
        /// Номер упаковки товара в прямом заказе.
        /// </summary>
        [JsonPropertyName("direct_package_number")]
        public string DirectPackageNumber { get; set; }
    }
}