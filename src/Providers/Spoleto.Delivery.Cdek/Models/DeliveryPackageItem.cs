using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Товар в упаковке.
    /// </summary>
    public record DeliveryPackageItem : DeliveryPackageItemBase
    {
        /// <summary>
        /// Количество врученных единиц товара (в штуках).
        /// </summary>
        [JsonPropertyName("delivery_amount")]
        public int? DeliveryAmount { get; set; }

        /// <summary>
        /// Информация по товарам в возвратном заказе (только для возвратного заказа).
        /// </summary>
        [JsonPropertyName("return_item_detail")]
        public ReturnItemDetail? ReturnItemDetail { get; set; }

        /// <summary>
        /// Признак подакцизности товара.
        /// </summary>
        [JsonPropertyName("excise")]
        public bool? Excise { get; set; }
    }
}
