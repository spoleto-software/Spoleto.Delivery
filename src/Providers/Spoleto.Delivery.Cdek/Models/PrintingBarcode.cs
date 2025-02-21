using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// ШК места в формате pdf к заказу/заказам.
    /// </summary>
    public record PrintingBarcode
    {
        /// <summary>
        /// Информация о ШК месте к заказу.
        /// </summary>
        [JsonPropertyName("entity")]
        public PrintingBarcodeEntity Entity { get; set; }

        /// <summary>
        /// Информация о запросе над квитанцией к заказу.
        /// </summary>
        [JsonPropertyName("requests")]
        public List<DeliveryRequestInfo> Requests { get; set; }

        /// <summary>
        /// Связанные сущности.
        /// </summary>
        [JsonPropertyName("related_entities")]
        public List<DeliveryOrderRelatedEntity>? RelatedEntities { get; set; }
    }
}
