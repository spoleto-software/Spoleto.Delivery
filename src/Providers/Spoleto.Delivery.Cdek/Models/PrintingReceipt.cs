using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Квитанция в формате pdf к заказу/заказам.
    /// </summary>
    /// <remarks>
    /// Ссылка на файл с квитанцией к заказу/заказам доступна в течение 1 часа.
    /// </remarks>
    public record PrintingReceipt
    {
        /// <summary>
        /// Информация о квитанции к заказу.
        /// </summary>
        [JsonPropertyName("entity")]
        public PrintingReceiptEntity Entity { get; set; }

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
