using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о ШК месте к заказу.
    /// </summary>
    public record CreatedPrintingBarcodeEntity
    {
        /// <summary>
        /// Идентификатор ШК места к заказу в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}
