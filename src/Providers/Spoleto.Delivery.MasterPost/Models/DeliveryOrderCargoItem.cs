using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Товар в созданном заказе.
    /// </summary>
    public record DeliveryOrderCargoItem : CargoItemBase
    {
        /// <summary>
        /// УИД строки артикулов.
        /// </summary>
        [JsonPropertyName("ART_UID")]
        public string ArticleUid { get; set; }

        /// <summary>
        /// Код маркировки в HEX представлении.
        /// </summary>
        [JsonPropertyName("ART_MARK_HEX")]
        public string ArticleMarkingHex { get; set; }

        /// <summary>
        /// Доставлено
        /// </summary>
        [JsonPropertyName("ART_DELIV")]
        public bool ArticleDelivered { get; set; }
    }
}
