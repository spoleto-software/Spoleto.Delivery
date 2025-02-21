using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о квитанции к заказу.
    /// </summary>
    public record CreatedPrintingReceiptEntity
    {
        /// <summary>
        /// Идентификатор квитанции к заказу в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}
